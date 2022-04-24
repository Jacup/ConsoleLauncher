# ConsoleLauncher [![build](https://github.com/Jacup/ConsoleLauncher/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Jacup/ConsoleLauncher/actions/workflows/dotnet.yml)

> ConsoleLaucher is simple tool for your .NET console application. ConsoleLauncher helps you to create useful and user-friedly navigation menu in  just two steps.


## Table of Contents

* [General Info](#general-information)
* [Features](#features--roadmap)
* [Get Started](#get-started)
* [~~Screenshots~~](#screenshots)
* [Contact](#contact)


## General Information

**ConsoleLauncher** is a .NET tool, that helps you to create simply, user-friendly console menu. Navigation is handled by using Arrows (alt. PgUp/Down), Enter, Esc.  
No longer force your users to write "yes/no". Console Apps are still fun in the XXI century, but make them more user-friendly!   


## Features / Roadmap

#### Tool: 
- [x] Print menu from options list 
- [x] Call method/actions from options list
- [ ] Add layout(header/footer) support
- [ ] Customize style(colors, keys)
- [ ] Unit tests

#### Environment: 
- [x] Add readme
- [ ] Automate build process:
    - [x] Build on PR push
    - [x] Automatic publishing to nuget.org
    - [ ] Automatic releases


## Get Started

### Download

Latest version is available always on [www.nuget.org/.../ConsoleLauncher](https://www.nuget.org/packages/ConsoleLauncher/)


### Installation via nuget.org

Install latest version
```ps
Install-Package ConsoleLauncher
```
*Until project is still released as preview version, please provide specific version, eg:*
```ps
Install-Package ConsoleLauncher -Version 0.x.x-alpha
```


### Usage


Definition of list of menu entries with actions :
```cs
List<Option> options = new()
{
    new Option("Submenu", Submenu),
    new Option("Option 1 as action", Option1),
    new Option("Option 1 as method", () => Option1()),
    new Option("Empty option 2"),
    new Option("Exit", () => Environment.Exit(0)),
};
```

Initializing menu:
```cs
Launcher.Menu(options);
```

_For more examples, please refer to the [ConsoleLauncher.Sample](https://github.com/Jacup/ConsoleLauncher/tree/main/ConsoleLauncher.Sample)_


## Screenshots

> TBD


## Contact

Created by [Jakub Gramburg (@Jacup)](https://github.com/Jacup) - feel free to contact me!
