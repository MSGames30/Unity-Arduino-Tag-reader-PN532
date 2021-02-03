
#if 0
#include <SPI.h>
#include <PN532_SPI.h>
#include <PN532.h>
#include <NfcAdapter.h>

PN532_SPI pn532spi(SPI, 10);
NfcAdapter nfc = NfcAdapter(pn532spi);
#else

#include <Wire.h>
#include <PN532_I2C.h>
#include <PN532.h>
#include <NfcAdapter.h>

PN532_I2C pn532_i2c(Wire);
NfcAdapter nfc = NfcAdapter(pn532_i2c);
#endif

void setup(void) {
    Serial.begin(9600);
    Serial.println("NDEF Reader");
    nfc.begin();
}

void loop(void) {
    //Serial.println("\nScan a NFC tag\n");
    
    if (nfc.tagPresent())
    {
        NfcTag tag = nfc.read();
        //if(tag.getUidString() == tag.getUidString())
        //{
           //Serial.println("\nOKKKKKKK : ");
           Serial.println(tag.getUidString());
           //Serial.println("1234");
        //}
        //tag.print();
    }
    else
    {
      Serial.println("NULL");
    }
    
    delay(1000);
}
