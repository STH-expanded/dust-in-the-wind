
# 3D Game

# Installation :gear:


## Requirements :clipboard:
In order to contribute to this project, you have to install : 
- [Unity Hub](https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe)
- [Unity (Version : 2020.1.14.f1)](unityhub://2020.1.14f1/d81f64f5201d)

In addition you have to :
- [Configure your IDE to work with Unity](https://docs.unity3d.com/Manual/ScriptingToolsIDEs.html)


## Quick Start

To start collaborating to the project, import it in Unity Hub and then, Enjoy !

# Git Flow :twisted_rightwards_arrows:	

### Several useful commands
- `git fetch origin` &rightarrow; update local repository based on distant repository
- `git checkout -b <branch_name>` &rightarrow; Create new branch and checkout on it
- `git push` &rightarrow; push local commits to distant repository
- `git commit -m <mesage>` &rightarrow; commit changes with message
- `git add -i` &rightarrow; interactive add files

### Branches rules
Two type of developments:
- `feature` &rightarrow; For a new feature
- `fix` &rightarrow; For resolving a bug

Each time you're intend to execute one action, you have to update your local repository with the remote one by taping the command `git fetch origin`.

Commit's message need to follow specific rules:
- `<type>(perimeter): subject`  
>The length of each commit message must be under 100 characters.


### Commit types

`feat`: New feature  
`fix`: Bug solving  
`refactor`: Code modification, don't affect logic or problem solving only code appearance and lisibility.  
`style`: Style modifications.  
`perf`: Code modifications that improve performances.  
`test`: Add and/or modify test files.  
`build`: Build system modification.  
`docs`: Documentation modifications.  
`misc`: Miscellaneous.

### Validation :white_check_mark:
In order to send a new feature in production, it needs to be verified in a pull/merge request. Before merging the new feature on the `dev` or `master` branch make sure you typed the following commands:
- `git fetch`
- `git rebase` 


And finally:
- `git push`
