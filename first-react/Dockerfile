# stage 1 - builder

FROM node:22.16 AS builder
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
ENV REACT_APP_ENVIRONMENT=development
ENV WATCHPACK_POLLING=true
ENV CHOKIDAR_USEPOLLING=true


# stage 2 - development
FROM builder AS development
EXPOSE 3000
CMD ["npm", "start"]


# stage 3 - production-builder
FROM builder AS production-builder
RUN npm run build


# stage 4 - production
FROM nginx:alpine AS production
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=production-builder /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]