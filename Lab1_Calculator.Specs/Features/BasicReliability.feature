Feature: UsingCalculatorBasicReliability
  In order to calculate the Basic Musa model's outputs
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

  @BasicMusa
  Scenario: Current failure intensity lambda(tau)
    Given I have a calculator
    When I enter lambda0 10, nu 100, tau 5 then press BasicMusaLambda
    Then the result should equal 9.512294245 within 0.000000001

  @BasicMusa
  Scenario: Expected failures mu(tau)
    Given I have a calculator
    When I enter lambda0 10, nu 100, tau 5 then press BasicMusaMu
    Then the result should equal 4.87705755 within 0.00001
