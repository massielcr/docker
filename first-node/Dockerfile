FROM node:24.6.0

LABEL description="This is my first node-application container."

RUN npm install -g cowsay

RUN useradd -ms /bin/bash carvedrock

COPY version.txt /opt/app/

USER carvedrock