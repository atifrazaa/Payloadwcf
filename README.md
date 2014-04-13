# Payloadwcf
==========

WCF service for processing payload
This is a rest base WCF service hosted at appharbor to process the payload data

The URL for the service is [Payload WCF Service](http://payloadwcf.apphb.com/payload.svc/payloads)


This service expects json  [input](https://github.com/mi9/coding-challenge-samples/blob/master/sample_request.json) and after processing returns json  [output](https://github.com/mi9/coding-challenge-samples/blob/master/sample_response.json)
listing  the **eligible programs**

In case of invalid JSON submitted to the service it will return below json based error key with a 400 bad request http 
status code.

"error": "Could not decode request: JSON parsing failed"

-----Technical specifications----

The Payload web service is a WCF Rest base web service developed in C#.

The main method is FilterPayload which processes the JSON input and returns the required payload in JSON format.

For  error handling, The "ProvideFault" method of IErrorHandler interface has been handled to process the incoming requests and provide the response in desired format.
