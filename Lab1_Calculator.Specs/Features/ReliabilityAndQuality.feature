Feature: UsingCalculatorReliabilityAndQuality
  In order to compute reliability and quality metrics
  As a reliability/quality analyst
  I want to use my calculator to do this


  # Epic: Enable quality engineers to extend the console calculator so they can compute software-quality metrics (defect density, successive-release SSI) 
  # and reliability forecasts via the Musa Logarithmic model—each from a single, repeatable command line workflow.

  # As a reliability analyst, I want to calculate current failure intensity λ(τ) using λ₀, θ, and τ so that I can track reliability improvement during testing.
  @MusaLog
  Scenario: Musa-Log current failure intensity lambda(tau)
    Given I have a calculator
    When I enter lambda0 20, theta 0.02, tau 50 then press MusaLogLambda
    Then the result should equal 0.9523809524 within 0.0000000001


  # As a reliability analyst, I want to compute expected cumulative failures μ(τ) from λ₀, θ, and τ so that I can plan test effort and release readiness.
  @MusaLog
  Scenario: Musa-Log expected failures mu(tau)
    Given I have a calculator
    When I enter lambda0 20, theta 0.02, tau 50 then press MusaLogMu
    Then the result should equal 152.226121886 within 0.000001

  # As a quality engineer, I want to compute defect density given total defects and size in KLOC so that I can compare quality across releases.
  @Quality
  Scenario: Defect density per KLOC
    Given I have a calculator
    When I enter defects 45 and sizeKLoc 120 then press DefectDensity
    Then the result should be 0.375

  # As a quality engineer, I want to compute the new total Shipped Source Instructions from previous total plus added/modified/deleted so that I can track codebase growth per release.
  @Quality
  Scenario: New total SSI for release N
    Given I have a calculator
    When I enter prevTotal 100000, added 12000, modified 3000, deleted 2000 then press NewTotalSSI
    Then the result should be 113000
