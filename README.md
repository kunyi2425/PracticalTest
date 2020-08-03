# Description
The test .NET project contatins all tests for both the testing Web site and Api. All tests are based on MS test framework together with selenium for web and auto rest for api respectively.
As there is no detailed behaviors defined for the calculators, assertions on negative cases are all passed for now. Ideally, these tests should be failed until bug fixes are made in real development process.

# Test scenarios:
1. Test all operators (+, -, *, /)
2. Test all different integers - positive, negative, zero
3. Test with largest integer and smallest integer 
4. Negative test divided by 0
5. API level testing - unauthorised, invalid input etc

# Azure DevOps demo set up at: 
https://dev.azure.com/kunyi2425/PracticalTest

# Refactored version with common lib at:
https://github.com/kunyi2425/PracticalTestsRefactored

# Test Common Project at:
https://github.com/kunyi2425/TestCommon

# Some findings:
1. Web calculator: -99 - 99 = 0 (expected to be -198)
2. Web calculator: 999 * 999 = 99800 (expected to be 998001, length of textbox needs to be set to 6 instead of 5)
3. Web calculator: 1 / 0 = 0 (expected to be error)
4. Web calculator: operator is displayed as '+' instead, but it does not function until a click.
5. Api calculator: returns 500 when divide a number by 0 (expected a customized error)
6. Api calculator: returns 500 when inputs are not integer (expected a customized error)

# None functional:
1. Web calculator: 1st calculation takes too long when calculator has not been used for a while.
2. Web calculator: Needs to update IE security settings to enable content in iframe.
