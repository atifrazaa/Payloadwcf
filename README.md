# Payloadwcf
==========

WCF service for processing payload
This is a rest base WCF service hosted at appharbor to process the payload data

The URL for the service is [Payload WCF Service!](http://payloadwcf.apphb.com/payload.svc/payloads)


This service expects json input and after processing returns json output listing  the *eligible programs**

In case of invalid JSON submitted to the service it will return below json based error key with a 400 bad request http 
status code.

"error": "Could not decode request: JSON parsing failed"
