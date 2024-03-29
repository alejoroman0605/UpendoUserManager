# Upendo-Dnn-UserManager

This module was created for user management in DNN.

## Requirements

The solution currently expects to be in the following environment, but you can update that to be any version you'd like, provided all extensions will be compatible:

- DNN: 09.10.02+
- SQL: 2014+

### First Time Builds & Deployments

When an extension is new to the solution, there may be an extra bit of setup required.

1. Build the extension in DEBUG mode so the deployment files are put into their respective places.
2. View the website and login as a superuser.
3. Manually install the extension in the Extensions view by using it's manifest file.
4. Add the extension to a page or otherwise use it as it's intended.

Alternatively, you can build the solution in RELEASE mode and install that package into the
website. Then build the solution/project again in DEBUG mode.

### Debugging

In order to debug the code, you'll need to follow the steps below:

1. Open Visual Studio using the "As Administrator" option in Windows.
2. Build the project(s) solution in DEBUG mode.
3. Ensure that the web.config is set to allow debugging: `<compilation debug="true" strict="false" optimizeCompilations="true">`
4. Run the website and view the page that contains the code you wish to debug.
5. In Visual Studio, choose the Debug > Attach to Process feature (a.k.a., `<Ctrl>`+`<Alt>`+`<P>`).
6. Find `w3wp.exe` in the list and click the Attach button.
7. Set any breakpoints that you wish to hit and step through.
8. View the page again and/or perform the steps necessary to hit the br

## Outstanding Features

- User management without using PersonaBar.
- Simplified administration of user roles.

## Contribution

- [Install and use the module (see below)](https://github.com/UpendoVentures/Upendo-Dnn-UserManager)
- [Create Issues (ideas OR bugs)](https://github.com/UpendoVentures/Upendo-Dnn-UserManager/wiki/Create-Issues-or-Ideas)
- [Write documentation](https://github.com/UpendoVentures/Upendo-Dnn-UserManager/wiki/Write-Documentation)
- [Test Releases](https://github.com/UpendoVentures/Upendo-Dnn-UserManager/wiki/Test-Releases)
- Create UI/UX
- [Write Code](https://github.com/UpendoVentures/Upendo-Dnn-UserManager/wiki/Write-Code)
- Debug Code
- [Create a Pull Request](https://github.com/UpendoVentures/Upendo-Dnn-UserManager/wiki/Create-a-Pull-Request)

# Support for this Project

This solution and the related materials are proudly created and provided by Upendo Ventures.

- [Visit Us](https://upendoventures.com/Support)
- [E-Mail Us](mailto:solutions@upendoventures.com)
- [Other Ways to Contact Us](https://upendoventures.com/Cont
