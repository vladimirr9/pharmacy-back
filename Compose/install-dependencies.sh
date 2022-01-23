#FRONTEND_APP_SRC_URL=$1
echo '----------------------------------------------------------------------------------------------------'
#apk update && apk add build-base dumb-init curl tar 
apk --update --no-cache add curl=7.67.0-r5 tar=1.32-r2 gettext=0.20.1-r2 && 
echo '----------------------------------------------------------------------------------------------------'
#curl -L "${FRONTEND_APP_SRC_URL}" | tar -xz && \
curl -L "https://github.com/PSW-Organization-8/pharmacy-front/archive/refs/heads/develop.tar.gz" | tar -xz && \
mv "$(find . -maxdepth 1 -type d | tail -n 1)" app && \
ls app &&\
cd app && \
cd pharmacy-app && \
ls &&\
npm install
