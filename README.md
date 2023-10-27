# Message-Kit

## How to run test cases for twilio

1) Test cases can be run using appsettings.json or environment variables.
2) appsettings.json already has settings option. Just change values with your respective values from twilio.

```json
{
  "TwilioOptions": {
    "AccountSid": "Your Account Id",
    "AuthToken": "Your Auth Token",
    "PhoneNumber": "Twilio Phone Number to send message from"
  }
}
```

3) To use environment variables make sure you add environment variables in your computer as follows

``` bash
export Twilio_TwilioOptions__AccountSid="Your Account Id"
export Twilio_TwilioOptions__AuthToken="Your Auth Token"
export Twilio_TwilioOptions__PhoneNumber="Twilio Phone Number to send message from"
```