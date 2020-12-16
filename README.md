<h1 align="center"> fetch.NET </h1>
<p align="center">
<img src="https://i.imgur.com/5f0LO35.png" align="center">
</p>
<h3>Como testar</h3>
1. Abra seu terminal

<ul>
    <li>Se você já tiver o .net core 3.1 instalado no seu computador</li>
    <ul>
        <li>git clone https://github.com/ArahirooriharA/fetch.NET.git</li>
        <li>cd ../fetch.net/fetch.net</li>
        <li>dotnet build</li>
        <li>cd ../bin/debug/netcoreapp3.1</li>
        <li>fetch.net</li>
    </ul>
    <li>Se você não tiver o .net core 3.1 instalado</li>
    <ul>
        <li>Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))</li>
        <li>choco install dotnetcore-sdk</li>
        <li>git clone https://github.com/ArahirooriharA/fetch.NET.git</li>
        <li>cd ../fetch.net/fetch.net</li>
        <li>dotnet build</li>
        <li>cd ../bin/debug/netcoreapp3.1</li>
        <li>fetch.net</li>
    </ul>
</ul>
