@ECHO OFF
@ECHO COPIA ARQUIVOS ERPTOOLS...

E:

CD \
CD E:\Desenvolvimento\Projetos\ErpTools\AtualizaERP\bin\x86


DEL E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP /q
MD E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP

COPY .\Release\AtualizaERP.exe E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\AtualizaERP.exe.config E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\AtualizaERP.pdb E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\AtualizaERP.XmlSerializers.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\DotNetZip.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\DotNetZip.xml E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\EPPlus.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\EPPlus.xml E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\GxClasses.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Interop.TaskScheduler.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\log4net.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.Office.Interop.Excel.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.SqlServer.ConnectionInfo.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.SqlServer.ConnectionInfoExtended.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.SqlServer.Management.Sdk.Sfc.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.SqlServer.Smo.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.SqlServer.SmoExtended.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.SqlServer.SqlClrProvider.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.SqlServer.SqlEnum.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.Win32.TaskScheduler.dll E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY .\Release\Microsoft.Win32.TaskScheduler.xml E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP
COPY E:\Desenvolvimento\Projetos\ErpTools\AtualizaERP\ControllerIco.ico E:\Desenvolvimento\Instaladores\Complementos\AtualizaERP

PAUSE
Microsoft.Office.Interop.Excel.dll
