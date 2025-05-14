Feature: Autenticación con credenciales válidas (US25)

  Escenario: Autenticación exitosa
  Given que el usuario tiene credenciales válidas
  When hace un POST a "/api/v1/authentication/sign-in"
  Then el sistema responde con 200 OK

  Escenario: Autenticación fallida
  Given que el usuario tiene credenciales inválidas
  When hace un POST a "/api/v1/authentication/sign-in"
  Then el sistema responde con 401 Unauthorized
