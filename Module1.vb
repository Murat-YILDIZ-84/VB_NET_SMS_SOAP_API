Imports System
Imports System.Net
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()

		Dim MyPhoneNumber As String = "905428421073"
		Dim HisPhoneNumber As String = "905310313097"
		Dim message_ as String = "Test message from SOAP UI"
        Dim SoapStr As String

        SoapStr = "<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sos=""http://www.openmindnetworks.com/SoS"">" & Chr(13) & Chr(10)
        SoapStr += "<soapenv:Header/>" & Chr(13) & Chr(10)
        SoapStr += "<soapenv:Body>" & Chr(13) & Chr(10)
        SoapStr += "<sos:SubmitSM soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">" & Chr(13) & Chr(10)
        SoapStr += "<smRequest xsi:type=""sos:SMRequest"">" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<serviceType xsi:type=""sos:string5"">?</serviceType>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<source xsi:type=""sos:Address"">" & Chr(13) & Chr(10)
        SoapStr += "<ton xsi:type=""sos:int1"">1</ton>" & Chr(13) & Chr(10)
        SoapStr += "<npi xsi:type=""sos:int1"">1</npi>" & Chr(13) & Chr(10)
        SoapStr += "<addr xsi:type=""sos:string20"">" & HisPhoneNumber & "</addr>" & Chr(13) & Chr(10)
        SoapStr += "</source>" & Chr(13) & Chr(10)
        SoapStr += "<destination xsi:type=""sos:Address"">" & Chr(13) & Chr(10)
        SoapStr += "<ton xsi:type=""sos:int1"">1</ton>" & Chr(13) & Chr(10)
        SoapStr += "<npi xsi:type=""sos:int1"">1</npi>" & Chr(13) & Chr(10)
        SoapStr += "<addr xsi:type=""sos:string20"">" & MyPhoneNumber & "</addr>" & Chr(13) & Chr(10)
        SoapStr += "</destination>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<esmClass xsi:type=""sos:int1"">0</esmClass>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<protocolID xsi:type=""sos:int1"">0</protocolID>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<!--priorityMode xsi:type=""sos:int1"">?</priorityMode-->" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<!--scheduleDeliveryTime xsi:type=""sos:string16"">?</scheduleDeliveryTime-->" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<validityPeriod xsi:type=""sos:string16"">000000000500000R</validityPeriod>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<registeredDelivery xsi:type=""sos:int1"">0</registeredDelivery>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<replaceIfPresentFlag xsi:type=""sos:int1"">0</replaceIfPresentFlag>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<dataCoding xsi:type=""sos:int1"">0</dataCoding>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<defaultMsgID xsi:type=""sos:int1"">0</defaultMsgID>" & Chr(13) & Chr(10)
        SoapStr += "<shortMessage xsi:type=""sos:MessageData"">" & Chr(13) & Chr(10)
        SoapStr += "<!--You have a CHOICE of the next 2 items at this level-->" & Chr(13) & Chr(10)
        SoapStr += "<!--hexData xsi:type=""sos:hexBinary510"">cid:1296763983911</hexData-->" & Chr(13) & Chr(10)
        SoapStr += "<stringData xsi:type=""sos:string255"">"& message_ &"</stringData>" & Chr(13) & Chr(10)
        SoapStr += "</shortMessage>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<tlvData xsi:type=""sos:TlvData"">" & Chr(13) & Chr(10)
        SoapStr += "<!--Zero or more repetitions:-->" & Chr(13) & Chr(10)
        SoapStr += "<tlv xsi:type=""sos:TLV"">" & Chr(13) & Chr(10)
        SoapStr += "<tag xsi:type=""sos:int2"">?</tag>" & Chr(13) & Chr(10)
        SoapStr += "<!--Optional:-->" & Chr(13) & Chr(10)
        SoapStr += "<type xsi:type=""sos:int1"">?</type>" & Chr(13) & Chr(10)
        SoapStr += "<value xsi:type=""sos:int2"">?</value>" & Chr(13) & Chr(10)
        SoapStr += "</tlv>" & Chr(13) & Chr(10)
        SoapStr += "</tlvData>" & Chr(13) & Chr(10)
        SoapStr += "</smRequest>" & Chr(13) & Chr(10)
        SoapStr += "</sos:SubmitSM>" & Chr(13) & Chr(10)
        SoapStr += "</soapenv:Body>" & Chr(13) & Chr(10)
        SoapStr += "</soapenv:Envelope>"

        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        Try
			'---------------------------------------------------------------------------------------
            'POST Http://IP_Address:Port/test HTTP/1.1
            'Accept-Encoding: gzip, deflate
            'SOAPAction: "SubmitSM"
            'Authorization: Basic "in Base64 Format"
            'Content - Type: Application/Xml
            'Content-Length:  Calculated From Text
            'Host: IP_Address:Port
            'Connection: Keep-Alive
            'User-Agent: Apache-HttpClient / 4.1.1 (java 1.5)

            Dim request As HttpWebRequest = HttpWebRequest.Create("http://IP_Address:Port/test")

			request.Credentials = New NetworkCredential("username", "password")
            request.Method = "POST"
            request.ProtocolVersion = HttpVersion.Version11
            request.Headers.Add("Accept-Encoding", "gzip,deflate")
            request.Headers.Add("SOAPAction", """SubmitSM""")
            request.Headers.Add("Authorization", "Basic ""in Base64 Format""")
            request.ContentType = "Application/Xml"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(SoapStr)
			
            request.ContentLength = byteArray.Length
            request.UserAgent = "Apache-HttpClient / 4.1.1 (java 1.5)"
            request.ServicePoint.Expect100Continue = False
			'---------------------------------------------------------------------------------------
			
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
  
            response = DirectCast(request.GetResponse(), HttpWebResponse)
  
            reader = New StreamReader(response.GetResponseStream())

            Dim response_ As String = reader.ReadToEnd()

            If response_.IndexOf("<messageID>") < 0 Then

                Console.WriteLine("SMS Error:" & MyPhoneNumber)

            End If

        Catch ex As Exception

            Console.WriteLine("SMS Error:" & ex.Message)

        Finally

            If Not response Is Nothing Then response.Close()

        End Try

        Console.ReadKey()

    End Sub

End Module
