FROM node:16.15.1 AS build
WORKDIR /app
COPY . .
RUN npm install && npm run build

FROM nginx:alpine
COPY --from=build /app/dist/confitec-technical-test /usr/share/nginx/html
EXPOSE 80