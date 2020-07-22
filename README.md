# Description
The test .NET project contatins all tests for both the testing Web site and Api. All tests are based on MS test framework together with selenium for web and auto rest for api respectively.
As there is no detailed behaviors defined for the calculators, assertions on negative cases are all passed for now. Ideally, these tests should be failed until bug fixes are made in real development process.
# Framework Design
For both the testing web site and the testing api, they both in nature are calculators no matter in what form. So I have decided to make their behaviors as consistent as possible, both WebCalculator (selenium page object) and the ApiCalculator follow the same contract. At test level, no matter which calculator is being tested, the way how tests are written are quite similiar. As a result, I can focus on the functionality of a calculator itself as well as keeping my tests simple and short.
