# Description
The test .NET project contatins all tests for both the testing Web site and Api. All tests are based on MS test framework together with selenium for web and auto rest for api respectively.
As there is no detailed behaviors defined for the calculators, assertions on negative cases are all passed for now. Ideally, these tests should be failed until bug fixes are made in real development process.

#Test scenarios:
1. Test all operators (+, -, *, /)
2. Test all different integers - positive, negative, zero
3. Test with largest integer and smallest integer 
4. Negative test divided by 0
5. API level testing - unauthorised, invalid input etc
