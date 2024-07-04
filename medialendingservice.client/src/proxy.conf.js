const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7090';

const PROXY_CONFIG = [
  {
    context: [
      "/api/v0/login",
      "/api/v0/register",
      "/api/v0/refresh",
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
