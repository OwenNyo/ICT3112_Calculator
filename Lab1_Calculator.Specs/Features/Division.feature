Feature: Division


@Divisions
Scenario: Divide two numbers
    Given I have a calculator
    When I divide 1 by 2
    Then the result should be 0.5