# Azure AD 응용 어플리케이션 등록

해당 프로젝트의 메일 전송을 위한 Auzre AD 응용 프로그램 등록은 다음과 같이 
진행됩니다.

필요한 부분은 수정하여 진행하시면 됩니다.

> Exchange API 권한 설정이 Azure Portal에서 안보이게 되어서 이 부분은 응용프로그램 [이 부분](#응용-어플리케이션-exchange-legacy-api-권한-추가)을 확인하시길 바랍니다.

## 응용 어플리케이션 등록
1. [Azure Portal](https://portal.azure.com)에 로그인합니다.

![](/images/register1.png)


2. 왼쪽 메뉴에서 **Azure Active Directory**를 선택한 후에 **앱 등록**을 선택합니다.

![](/images/register2.png)


3. 상단에 **새 등록**을 누르면 **어플리케이션 등록** 페이지가 활성화 됩니다. 다음과 같이 입력합니다.
    -  이름: **EWSOAuthExampleApp**
    -  지원되는 계정 유형: **이 조직의 디렉토리 계정만**
    -  리다이렉션 URI: 
       -  웹 : **http://localhost:8080/permissions**
       -  모바일 또는 데스크톱 : **urn:ietf:wg:oauth:2.0:oob**

![](/images/register22.png)

4. **등록** 버튼을 누릅니다. 응용 프로그램 페이지가 활성화되는데 여기서 **디렉터리(테넌트) ID**와 **어플리케이션 (클라이언트) ID**를 복사 후 저장합니다. 추후에 사용됩니다.

![](/images/register3.png)

5. 왼쪽 메뉴에 **관리** 부분에 **인증서 및 암호**를 선택합니다.
 
![](/images/register4.png)

6. **새 클라이언트 암호**를 선택한후 간단하게 설명을 입력한 후에 **추가**를 누릅니다.

![](/images/register5.png)

7. 생성된 클라이언트 암호는 복사해서 기록해 둡니다. 추후에 사용됩니다.

![](/images/register6.png)


## 응용 어플리케이션 Exchange Legacy API 권한 추가

1. [Azure 명령툴](https://docs.microsoft.com/ko-kr/cli/azure/install-azure-cli-windows?tabs=azure-cli)을 다운로드 받아서 설치합니다.
2. 설치완료 후 원도우 터미널 창을 Open한 후 다음 명령으로 Azure에 로그인합니다.
```console
> az login
```
3. 다음 명령으로 앞에서 생성한 응용 프로그램에 Exchange 권한을 활성화 시킵니다.
 *client-id* 는 앞에 생성한 응용어플리케이션 ID를 입력하시면 됩니다.

```console
> az ad app permission add --id <client-id> --api 00000002-0000-0ff1-ce00-000000000000 --api-permissions 3b5f3d61-589b-4a3c-a359-5dd4b5ee5bd5=Scope
> az ad app permission add --id <client-id> --api 00000002-0000-0ff1-ce00-000000000000 --api-permissions dc890d15-9560-4a4c-9b7f-a736ec74ec40=Role
```

![](/images/register7.png)

> Permission 정보는 **Get-AzureADPermission.ps1**으로 확인 할수 있습니다.

## 참고
- [azure cli 로그인 참조](https://docs.microsoft.com/ko-kr/cli/azure/authenticate-azure-cli)
- [azure cli 권한 추가 참조](https://docs.microsoft.com/en-us/cli/azure/ad/app/permission?view=azure-cli-latest#az_ad_app_permission_add)