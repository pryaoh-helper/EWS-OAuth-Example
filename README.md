# EWS OAuth 인증 
Azure Active Directory(AAD)에서 제공하는 OAuth 인증 서비스를 사용하여 EWS Managed API 애플리케이션이 Office 365의 Exchange Online에 접속하는 방법을 예제와 함께 안내합니다.

## 순서
1. [Azure AD 응용 어플리케이션 등록](./Resister_Application.md)
2. 데모 프로그램 실행


## 데모 프로그램 실행

- [App.config](./example/EWSOAuthDemo/App.config) 파일에 1에서 생성한 응용 어플리케이션 정보를 적용합니다.

```xml
 <appSettings>
    <add key="tenantId" value="<tenantId>" />
    <add key="clientId" value="<clientid>" />
    <add key="clientSecret" value="<clientSecert>" />
  </appSettings>
```

- 프로젝트 빌드 

```console
PS> ./example/build.ps1
```

- 프로그램 실행

```console
> ./example/EWSAuthDemo/bin/Release/EWSOAuthDemo.exe -a
```


## 참조
- [EWS 응용프로그램 OAuth 인증](https://docs.microsoft.com/en-us/exchange/client-developer/exchange-web-services/how-to-authenticate-an-ews-application-by-using-oauth#register-your-application)
