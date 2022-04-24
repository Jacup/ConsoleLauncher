# ConsoleLauncher
> ConsoleLaucher is simple tool for your .NET console application. It allows you to create useful navigation menu, a
> Live demo [_here_](https://www.example.com). <!-- If you have the project hosted somewhere, include the link here. -->

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Features](#features)
* [Screenshots](#screenshots)
* [Setup](#setup)
* [Usage](#usage)
* [Project Status](#project-status)
* [Room for Improvement](#room-for-improvement)
* [Acknowledgements](#acknowledgements)
* [Contact](#contact)
<!-- * [License](#license) -->


## General Information
- Provide general information about your project here.
- What problem does it (intend to) solve?
- What is the purpose of your project?
- Why did you undertake it?
<!-- You don't have to answer all the questions - just the ones relevant to your project. -->


## Technologies Used
- Tech 1 - version 1.0
- Tech 2 - version 2.0
- Tech 3 - version 3.0


## Features
List the ready features here:
- Awesome feature 1
- Awesome feature 2
- Awesome feature 3


## Screenshots
![Example screenshot](./img/screenshot.png)
<!-- If you have screenshots you'd like to share, include them here. -->


## Setup
What are the project requirements/dependencies? Where are they listed? A requirements.txt or a Pipfile.lock file perhaps? Where is it located?

Proceed to describe how to install / setup one's local environment / get started with the project.


## Usage
How does one go about using it?
Provide various use cases and code examples here.

`write-your-code-here`


## Project Status
Project is: _in progress_ / _complete_ / _no longer being worked on_. If you are no longer working on it, provide reasons why.


## Room for Improvement
Include areas you believe need improvement / could be improved. Also add TODOs for future development.

Room for improvement:
- Improvement to be done 1# ConsoleLauncher ![build](https://github.com/Jacup/ConsoleLauncher/blob/main/.github/workflows/dotnet.yml/badge.svg) ![latest version](https://github.com/Jacup/ConsoleLauncher/blob/main/.github/workflows/publish.yml/badge.svg)
> ConsoleLaucher is simple tool for your .NET console application. ConsoleLauncher helps you to create useful and user-friedly navigation menu in  just two steps.

## Table of Contents
* [General Info](#general-information)
* [Features](#features-/-roadmap)
* [Get Started](#get-started)
* [~~Screenshots~~](#screenshots)
* [Contact](#contact)


## General Information
**ConsoleLauncher** is a .NET tool, that helps you to create simply, user-friendly console menu. Navigation is handled by using Arrows (alt. PgUp/Down), Enter, Esc.  
No longer force your users to write "yes/no". Console Apps are still fun in the XXI century, but make them more user-friendly!   


## Features / Roadmap
##### Tool: 
- [x] Print menu from options list 
- [x] Call method/actions from options list
- [ ] Add layout(header/footer) support
- [ ] Customize style(colors, keys)

##### Environment features: 
- [x] Add readme
- [ ] Automate build process:
    - [x] Build on PR push
    - [x] Automatic publishing to nuget.org
    - [ ] Automatic releases


## Get Started

### Download

Latest version is available always on [www.nuget.org/.../ConsoleLauncher](https://www.nuget.org/packages/ConsoleLauncher/0.1.3-alpha)


### Installation via nuget.org

1. Install latest version
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

- Improvement to be done 2

To do:
- Feature to be added 1
- Feature to be added 2


## Acknowledgements
Give credit here.
- This project was inspired by...
- This project was based on [this tutorial](https://www.example.com).
- Many thanks to...


## Contact
Created by [@flynerdpl](https://www.flynerd.pl/) - feel free to contact me!


<!-- Optional -->
<!-- ## License -->
<!-- This project is open source and available under the [... License](). -->

<!-- You don't have to include all sections - just the one's relevant to your project -->