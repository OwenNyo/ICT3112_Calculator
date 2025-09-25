Feature: Magic number generation
  As a user of the Calculator
  I want to generate a magic number from a file
  So that I can get a deterministic doubled magnitude

  Background:
    Given I have a calculator

  Scenario: Positive value doubles to positive
    Given a magic numbers file containing:
      | value |
      | 5     |
      | -8    |
      | 0     |
    When I generate the magic number from 0
    Then the result should be 10

  Scenario: Negative value becomes doubled absolute
    Given a magic numbers file containing:
      | value |
      | 5     |
      | -8    |
      | 0     |
    When I generate the magic number from 1
    Then the result should be 16

  Scenario: Zero yields zero
    Given a magic numbers file containing:
      | value |
      | 5     |
      | -8    |
      | 0     |
    When I generate the magic number from 2
    Then the result should be 0

  Scenario: Index out of range returns zero
    Given a magic numbers file containing:
      | value |
      | 5     |
      | -8    |
      | 0     |
    When I generate the magic number from 99
    Then the result should be 0

  Scenario: Non-integer input rounds to nearest index
    # Convert.ToInt16(1.9) -> 2, selects the "0" line above
    Given a magic numbers file containing:
      | value |
      | 5     |
      | -8    |
      | 0     |
    When I generate the magic number from 1.9
    Then the result should be 0
