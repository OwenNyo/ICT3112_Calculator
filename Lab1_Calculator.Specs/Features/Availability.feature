Feature: UsingCalculatorAvailability
  In order to calculate MTBF and Availability
  As someone who struggles with math
  I want to be able to use my calculator to do this

  @Availability
  Scenario: Calculating MTBF
    Given I have a calculator
    When I enter 100 and 10 then press MTBF
    Then the result text should be "110"

  @Availability
  Scenario: Calculating Availability
    Given I have a calculator
    When I enter 100 and 10 then press Availability
    Then the result text should be "0.9090909091"
