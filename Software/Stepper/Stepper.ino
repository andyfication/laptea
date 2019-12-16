#include <Stepper.h>
char val; // Data received from the serial port
int bag_speed =  10;
#define STEPS 3000 // the number of steps in one revolution of the motor Data Sheet

Stepper stepper(STEPS, 8, 10, 9, 11);

void setup() {
  
  //initialize serial communications at a 9600 baud rate
  Serial.begin(9600);
  //initialise the stepper speed
  teaBagSetup(bag_speed);
}

void loop() {

  if (Serial.available() > 0) { // If data is available to read,
    val = Serial.read(); // read it and store it in val
    if (val == '0') // Unity main menu
    {
      teaBagUp(); // recoil teaBag
    }
    else if (val == '1')// Unity tea infusion mode
    {
      teaBagDown();// drop teaBag
    }
  }
}


void teaBagSetup(int _speed)
{
  stepper.setSpeed(_speed);
}

void teaBagUp()
{
  stepper.step(-3000);
}

void teaBagDown(){
  stepper.step(3000);
}

