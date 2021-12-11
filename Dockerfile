
FROM node:15.14.0-alpine AS frontBuild
#FROM node:16-alpine3.13 AS frontBuild
WORKDIR /src
COPY ./install-dependencies.sh .
#RUN apk update && apk add build-base dumb-init curl tar 
#ARG FRONTEND_APP_SRC_URL='https://github.com/PSW-Organization-8/pharmacy-front/archive/refs/heads/develop.tar.gz'
SHELL ["/bin/ash", "-o", "pipefail", "-c"]
RUN chmod +x ./install-dependencies.sh && \
    ./install-dependencies.sh
#RUN chmod +x ./install-dependencies.sh && \
#    ./install-dependencies.sh ${FRONTEND_APP_SRC_URL}
COPY ./environment.ts.template ./app
COPY ./build-app.sh .
ARG SMART_TUTOR_API_URL

RUN chmod +x ./build-app.sh && \
    ./build-app.sh ${SMART_TUTOR_API_URL}

FROM nginx:1.19.8-alpine AS gatewayWithFront
COPY --from=frontBuild /app /usr/share/nginx/html/app
COPY ./nginx.conf /etc/nginx/nginx.conf
COPY ./api_gateway.conf /etc/nginx/api_gateway.conf
