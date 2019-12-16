char val; // Data received from the serial port
int ledPin = 13; // Set the pin to digital I/O 13



void setup() 
{
  pinMode(ledPin, OUTPUT); // Set pin as OUTPUT
  //initialize serial communications at a 9600 baud rate
  Serial.begin(9600);
 
}


void loop()
{
  if (Serial.available() > 0) { // If data is available to read,
    val = Serial.read(); // read it and store it in val
  

    
    if (val == '0')
    {
      digitalWrite(ledPin, LOW); 
  
    }

    else if (val == '1')
    {
 
       digitalWrite(ledPin, HIGH); 
    }

 
    delay(100);
  }
} 
    



