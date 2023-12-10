This program is meant to use numerical solving methods to model physics problems that can't be solved analytically. 
Projectile Simulator: models either a cannonball or arrow in three dimensions under the influence of air resistance and a crosswind. 
Parachuter Descent: models the descent of a parachuter with a standard military parachute.
Rocket Trajectory: models the flight of a rocket under the influence of drag.
Aiming Aid: uses the bisection method to calculate the necessary launch angle to hit a target at a user-inputted location. Also accounts for an adjustment angle needed to counteract a crosswind if present.
Assumptions that were made for each model are listed at the top of their respective class.

If you don't know what values to pick to test, here are some standard ranges:

Wind
Direction: any, just keep in mind that a positive angle is measured to the left of the line between the launcher and the target
Speed: hurricanes are over 32 m/s, so maybe stay below that. A strong breeze is about 10 m/s

Projectile Simulator
Mass: 0.1-30 kg
Launch angle: 0-90 degrees
Launch velocity: 0 is okay if your starting height is greater than 0. Cannonballs can be lauched at high speeds, arrows aren't usually more than 100 m/s

Parachuter Descent
Mass: 60-120 kg. Double it if you want to model tandem skydiving
Drop Altitude: I've tested this simulation up to 40,000 m and it works, but most skydiving is closer to 3,000 m
Parachute Deploy Height: 1500 m is treated as the minimum deploy height

Rocket Trajectory (this is what I used from an old physics homework problem)
Mass: 180 kg
Fuel mass: 130 kg
Burn rate: 2.5 m/s
Exhaust Velocity: 1500 m/s
Launch angle: 90 is best for getting height, but it should work if you go lower
Diameter: 0.4 m

Aiming Aid
Some combinations are not possible, for example, trying to go 100m with a launch velocity of 1 m/s!!!
In the future I will add in a method that checks this, but for now make sure that your distance is less than one tenth of your launch velocity squared.
