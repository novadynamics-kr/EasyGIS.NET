@echo off
REM 현재 디렉터리와 하위 디렉터리에서 'bin'과 'obj' 폴더 삭제

REM 삭제할 폴더 이름 목록
set foldersToDelete=bin obj

REM 삭제 확인 메시지 표시
echo 현재 디렉터리와 하위 디렉터리에서 'bin'과 'obj' 폴더를 삭제합니다.

REM 폴더 삭제 실행
for %%f in (%foldersToDelete%) do (
    for /d /r %%d in (%%f) do (
        echo 삭제 중: %%d
        rd /s /q "%%d"
    )
)

echo 모든 'bin' 및 'obj' 폴더가 삭제되었습니다.
pause