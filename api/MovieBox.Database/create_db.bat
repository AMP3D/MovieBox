cd %~dp0
if not exist ..\MovieBox\Movies.sqlite sqlite3.exe ..\MovieBox\Movies.sqlite ".read script.sql"