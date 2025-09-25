Feature: UsingCalculatorFactorial
  In order to compute factorials
  As someone who struggles with math
  I want to use my calculator to do this

  @Factorial
  Scenario: Factorial of a positive integer
    Given I have a calculator
    When I enter 5 then press factorial
    Then the result should be 120

  @Factorial
  Scenario: Factorial of zero
    Given I have a calculator
    When I enter 0 then press factorial
    Then the result should be 1
