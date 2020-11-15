# Azure AD 응용 프로그램 등록 및 수정

해당 프로젝트의 메일 전송을 위한 Auzre AD 응용 프로그램 등록은 다음과 같이 
진행됩니다.

필요한 부분은 수정하여 진행하시면 됩니다.

## 응용 프로그램 생성
1. [Azure Portal](https://portal.azure.com)에 로그인합니다.
2. 왼쪽 메뉴에서 **Azure Active Directory**를 선택한 후에 앱 등록을 선택합니다.
3. 상단에 새 등록을 누르고 다음과 같이 입력합니다. (전부 나중에 수정 가능합니다.)
    -  이름: **sendMailExampleApp**
    -  지원되는 계정 유형: **모든 조직 디렉토리의 계정**
    -  리다이렉션 URI: **http://localhost:8080/permissions**