﻿/*
 * Copyright (c) 2014-2021 GraphDefined GmbH
 * This file is part of WWCP OCPP <https://github.com/OpenChargingCloud/WWCP_OCPP>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.Xml.Linq;

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Illias;

#endregion

namespace cloud.charging.open.protocols.OCPPv1_6.CP
{

    /// <summary>
    /// The StatusNotification request.
    /// </summary>
    public class StatusNotificationRequest : ARequest<StatusNotificationRequest>
    {

        #region Properties

        /// <summary>
        /// The connector identification at the charge point.
        /// Id '0' (zero) is used if the status is for the charge point main controller.
        /// </summary>
        public Connector_Id           ConnectorId        { get; }

        /// <summary>
        /// The current status of the charge point.
        /// </summary>
        public ChargePointStatus      Status             { get; }

        /// <summary>
        /// The error code reported by the charge point.
        /// </summary>
        public ChargePointErrorCodes  ErrorCode          { get; }

        /// <summary>
        /// Additional free format information related to the error.
        /// </summary>
        public String                 Info               { get; }

        /// <summary>
        /// The time for which the status is reported.
        /// </summary>
        public DateTime?              StatusTimestamp    { get; }

        /// <summary>
        /// This identifies the vendor-specific implementation.
        /// </summary>
        public String                 VendorId           { get; }

        /// <summary>
        /// A vendor-specific error code.
        /// </summary>
        public String                 VendorErrorCode    { get; }

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Create a new StatusNotification request.
        /// </summary>
        /// <param name="ChargeBoxId">The charge box identification.</param>
        /// <param name="ConnectorId">The connector identification at the charge point.</param>
        /// <param name="Status">The current status of the charge point.</param>
        /// <param name="ErrorCode">The error code reported by the charge point.</param>
        /// 
        /// <param name="Info">Additional free format information related to the error.</param>
        /// <param name="StatusTimestamp">The time for which the status is reported.</param>
        /// <param name="VendorId">This identifies the vendor-specific implementation.</param>
        /// <param name="VendorErrorCode">A vendor-specific error code.</param>
        /// 
        /// <param name="RequestId">An optional request identification.</param>
        /// <param name="RequestTimestamp">An optional request timestamp.</param>
        public StatusNotificationRequest(ChargeBox_Id           ChargeBoxId,
                                         Connector_Id           ConnectorId,
                                         ChargePointStatus      Status,
                                         ChargePointErrorCodes  ErrorCode,

                                         String                 Info               = null,
                                         DateTime?              StatusTimestamp    = null,
                                         String                 VendorId           = null,
                                         String                 VendorErrorCode    = null,

                                         Request_Id?            RequestId          = null,
                                         DateTime?              RequestTimestamp   = null)

            : base(ChargeBoxId,
                   "StatusNotification",
                   RequestId,
                   RequestTimestamp)

        {

            this.ConnectorId      = ConnectorId;
            this.Status           = Status;
            this.ErrorCode        = ErrorCode;

            this.Info             = Info?.           Trim(); // max  50
            this.StatusTimestamp  = StatusTimestamp;
            this.VendorId         = VendorId?.       Trim(); // max 255
            this.VendorErrorCode  = VendorErrorCode?.Trim(); // max  50

        }

        #endregion


        #region Documentation

        // <soap:Envelope xmlns:soap = "http://www.w3.org/2003/05/soap-envelope"
        //                xmlns:wsa  = "http://www.w3.org/2005/08/addressing"
        //                xmlns:ns   = "urn://Ocpp/Cs/2015/10/">
        //
        //    <soap:Header>
        //       ...
        //    </soap:Header>
        //
        //    <soap:Body>
        //       <ns:statusNotificationRequest>
        //
        //          <ns:connectorId>?</ns:connectorId>
        //          <ns:status>?</ns:status>
        //          <ns:errorCode>?</ns:errorCode>
        //
        //          <!--Optional:-->
        //          <ns:info>?</ns:info>
        //
        //          <!--Optional:-->
        //          <ns:timestamp>?</ns:timestamp>
        //
        //          <!--Optional:-->
        //          <ns:vendorId>?</ns:vendorId>
        //
        //          <!--Optional:-->
        //          <ns:vendorErrorCode>?</ns:vendorErrorCode>
        //
        //       </ns:statusNotificationRequest>
        //    </soap:Body>
        //
        // </soap:Envelope>

        // {
        //     "$schema":  "http://json-schema.org/draft-04/schema#",
        //     "id":       "urn:OCPP:1.6:2019:12:StatusNotificationRequest",
        //     "title":    "StatusNotificationRequest",
        //     "type":     "object",
        //     "properties": {
        //         "connectorId": {
        //             "type": "integer"
        //         },
        //         "errorCode": {
        //             "type": "string",
        //             "additionalProperties": false,
        //             "enum": [
        //                 "ConnectorLockFailure",
        //                 "EVCommunicationError",
        //                 "GroundFailure",
        //                 "HighTemperature",
        //                 "InternalError",
        //                 "LocalListConflict",
        //                 "NoError",
        //                 "OtherError",
        //                 "OverCurrentFailure",
        //                 "PowerMeterFailure",
        //                 "PowerSwitchFailure",
        //                 "ReaderFailure",
        //                 "ResetFailure",
        //                 "UnderVoltage",
        //                 "OverVoltage",
        //                 "WeakSignal"
        //             ]
        //         },
        //         "info": {
        //             "type": "string",
        //             "maxLength": 50
        //         },
        //         "status": {
        //             "type": "string",
        //             "additionalProperties": false,
        //             "enum": [
        //                 "Available",
        //                 "Preparing",
        //                 "Charging",
        //                 "SuspendedEVSE",
        //                 "SuspendedEV",
        //                 "Finishing",
        //                 "Reserved",
        //                 "Unavailable",
        //                 "Faulted"
        //             ]
        //         },
        //         "timestamp": {
        //             "type": "string",
        //             "format": "date-time"
        //         },
        //         "vendorId": {
        //             "type": "string",
        //             "maxLength": 255
        //         },
        //         "vendorErrorCode": {
        //             "type": "string",
        //             "maxLength": 50
        //         }
        //     },
        //     "additionalProperties": false,
        //     "required": [
        //         "connectorId",
        //         "errorCode",
        //         "status"
        //     ]
        // }

        #endregion

        #region (static) Parse   (XML,  RequestId, ChargeBoxId, OnException = null)

        /// <summary>
        /// Parse the given XML representation of a StatusNotification request.
        /// </summary>
        /// <param name="XML">The XML to be parsed.</param>
        /// <param name="RequestId">The request identification.</param>
        /// <param name="ChargeBoxId">The charge box identification.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static StatusNotificationRequest Parse(XElement             XML,
                                                      Request_Id           RequestId,
                                                      ChargeBox_Id         ChargeBoxId,
                                                      OnExceptionDelegate  OnException = null)
        {

            if (TryParse(XML,
                         RequestId,
                         ChargeBoxId,
                         out StatusNotificationRequest statusNotificationRequest,
                         OnException))
            {
                return statusNotificationRequest;
            }

            throw new ArgumentException("The given XML representation of a StatusNotification request is invalid!", nameof(XML));

        }

        #endregion

        #region (static) Parse   (JSON, RequestId, ChargeBoxId, CustomStatusNotificationRequestParser = null)

        /// <summary>
        /// Parse the given JSON representation of a StatusNotification request.
        /// </summary>
        /// <param name="JSON">The JSON to be parsed.</param>
        /// <param name="RequestId">The request identification.</param>
        /// <param name="ChargeBoxId">The charge box identification.</param>
        /// <param name="CustomStatusNotificationRequestParser">A delegate to parse custom CustomStatusNotification requests.</param>
        public static StatusNotificationRequest Parse(JObject                                                 JSON,
                                                      Request_Id                                              RequestId,
                                                      ChargeBox_Id                                            ChargeBoxId,
                                                      CustomJObjectParserDelegate<StatusNotificationRequest>  CustomStatusNotificationRequestParser   = null)
        {

            if (TryParse(JSON,
                         RequestId,
                         ChargeBoxId,
                         out StatusNotificationRequest  statusNotificationRequest,
                         out String                     ErrorResponse,
                         CustomStatusNotificationRequestParser))
            {
                return statusNotificationRequest;
            }

            throw new ArgumentException("The given JSON representation of a StatusNotification request is invalid: " + ErrorResponse, nameof(JSON));

        }

        #endregion

        #region (static) Parse   (Text, RequestId, ChargeBoxId, OnException = null)

        /// <summary>
        /// Parse the given text representation of a StatusNotification request.
        /// </summary>
        /// <param name="Text">The text to be parsed.</param>
        /// <param name="RequestId">The request identification.</param>
        /// <param name="ChargeBoxId">The charge box identification.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static StatusNotificationRequest Parse(String               Text,
                                                      Request_Id           RequestId,
                                                      ChargeBox_Id         ChargeBoxId,
                                                      OnExceptionDelegate  OnException = null)
        {

            if (TryParse(Text,
                         RequestId,
                         ChargeBoxId,
                         out StatusNotificationRequest statusNotificationRequest,
                         OnException))
            {
                return statusNotificationRequest;
            }

            throw new ArgumentException("The given text representation of a StatusNotification request is invalid!", nameof(Text));

        }

        #endregion

        #region (static) TryParse(XML,  RequestId, ChargeBoxId, out StatusNotificationRequest, OnException = null)

        /// <summary>
        /// Try to parse the given XML representation of a StatusNotification request.
        /// </summary>
        /// <param name="XML">The XML to be parsed.</param>
        /// <param name="RequestId">The request identification.</param>
        /// <param name="ChargeBoxId">The charge box identification.</param>
        /// <param name="StatusNotificationRequest">The parsed StatusNotification request.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static Boolean TryParse(XElement                       XML,
                                       Request_Id                     RequestId,
                                       ChargeBox_Id                   ChargeBoxId,
                                       out StatusNotificationRequest  StatusNotificationRequest,
                                       OnExceptionDelegate            OnException  = null)
        {

            try
            {

                StatusNotificationRequest = new StatusNotificationRequest(

                                                ChargeBoxId,

                                                XML.MapValueOrFail       (OCPPNS.OCPPv1_6_CS + "connectorId",
                                                                          Connector_Id.Parse),

                                                XML.MapEnumValuesOrFail  (OCPPNS.OCPPv1_6_CS + "status",
                                                                          ChargePointStatusExtentions.Parse),

                                                XML.MapEnumValuesOrFail  (OCPPNS.OCPPv1_6_CS + "errorCode",
                                                                          ChargePointErrorCodeExtentions.Parse),

                                                XML.ElementValueOrDefault(OCPPNS.OCPPv1_6_CS + "info"),

                                                XML.MapValueOrNullable   (OCPPNS.OCPPv1_6_CS + "timestamp",
                                                                          DateTime.Parse),

                                                XML.ElementValueOrDefault(OCPPNS.OCPPv1_6_CS + "vendorId"),

                                                XML.ElementValueOrDefault(OCPPNS.OCPPv1_6_CS + "vendorErrorCode"),

                                                RequestId

                                            );

                return true;

            }
            catch (Exception e)
            {

                OnException?.Invoke(DateTime.UtcNow, XML, e);

                StatusNotificationRequest = null;
                return false;

            }

        }

        #endregion

        #region (static) TryParse(JSON, RequestId, ChargeBoxId, out CustomStatusNotificationRequestParser, OnException = null)

        // Note: The following is needed to satisfy pattern matching delegates! Do not refactor it!

        /// <summary>
        /// Try to parse the given JSON representation of a StatusNotification request.
        /// </summary>
        /// <param name="JSON">The JSON to be parsed.</param>
        /// <param name="RequestId">The request identification.</param>
        /// <param name="ChargeBoxId">The charge box identification.</param>
        /// <param name="StatusNotificationRequest">The parsed StatusNotification request.</param>
        /// <param name="ErrorResponse">An optional error response.</param>
        public static Boolean TryParse(JObject                        JSON,
                                       Request_Id                     RequestId,
                                       ChargeBox_Id                   ChargeBoxId,
                                       out StatusNotificationRequest  StatusNotificationRequest,
                                       out String                     ErrorResponse)

            => TryParse(JSON,
                        RequestId,
                        ChargeBoxId,
                        out StatusNotificationRequest,
                        out ErrorResponse,
                        null);


        /// <summary>
        /// Try to parse the given JSON representation of a StatusNotification request.
        /// </summary>
        /// <param name="JSON">The JSON to be parsed.</param>
        /// <param name="RequestId">The request identification.</param>
        /// <param name="ChargeBoxId">The charge box identification.</param>
        /// <param name="StatusNotificationRequest">The parsed StatusNotification request.</param>
        /// <param name="ErrorResponse">An optional error response.</param>
        /// <param name="CustomStatusNotificationRequestParser">A delegate to parse custom CustomStatusNotification requests.</param>
        public static Boolean TryParse(JObject                                                 JSON,
                                       Request_Id                                              RequestId,
                                       ChargeBox_Id                                            ChargeBoxId,
                                       out StatusNotificationRequest                           StatusNotificationRequest,
                                       out String                                              ErrorResponse,
                                       CustomJObjectParserDelegate<StatusNotificationRequest>  CustomStatusNotificationRequestParser)
        {

            try
            {

                StatusNotificationRequest = null;

                #region ConnectorId        [mandatory]

                if (!JSON.ParseMandatory("connectorId",
                                         "connector identification",
                                         Connector_Id.TryParse,
                                         out Connector_Id ConnectorId,
                                         out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region Status             [mandatory]

                if (!JSON.MapMandatory("status",
                                       "status",
                                       ChargePointStatusExtentions.Parse,
                                       out ChargePointStatus Status,
                                       out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region ErrorCode          [mandatory]

                if (!JSON.MapMandatory("errorCode",
                                       "error code",
                                       ChargePointErrorCodeExtentions.Parse,
                                       out ChargePointErrorCodes ErrorCode,
                                       out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region Info               [mandatory]

                if (!JSON.ParseOptional("info",
                                        "info",
                                        out String Info,
                                        out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region Timestamp          [mandatory]

                if (!JSON.ParseMandatory("timestamp",
                                         "timestamp",
                                         out DateTime Timestamp,
                                         out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region VerndorId          [optional]

                if (!JSON.ParseOptional("verndorId",
                                        "verndor identification",
                                        out String VerndorId,
                                        out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region VendorErrorCode    [optional]

                if (!JSON.ParseOptional("vendorErrorCode",
                                        "vendor error code",
                                        out String VendorErrorCode,
                                        out ErrorResponse))
                {
                    return false;
                }

                #endregion

                #region ChargeBoxId        [optional, OCPP_CSE]

                if (JSON.ParseOptional("chargeBoxId",
                                       "charge box identification",
                                       ChargeBox_Id.TryParse,
                                       out ChargeBox_Id? chargeBoxId_PayLoad,
                                       out ErrorResponse))
                {

                    if (ErrorResponse != null)
                        return false;

                    if (chargeBoxId_PayLoad.HasValue)
                        ChargeBoxId = chargeBoxId_PayLoad.Value;

                }

                #endregion


                StatusNotificationRequest = new StatusNotificationRequest(ChargeBoxId,
                                                                          ConnectorId,
                                                                          Status,
                                                                          ErrorCode,

                                                                          Info,
                                                                          Timestamp,
                                                                          VerndorId,
                                                                          VendorErrorCode,
                                                                          RequestId);

                if (CustomStatusNotificationRequestParser != null)
                    StatusNotificationRequest = CustomStatusNotificationRequestParser(JSON,
                                                                                      StatusNotificationRequest);

                return true;

            }
            catch (Exception e)
            {
                StatusNotificationRequest  = default;
                ErrorResponse              = "The given JSON representation of a StatusNotification request is invalid: " + e.Message;
                return false;
            }

        }

        #endregion

        #region (static) TryParse(Text, RequestId, ChargeBoxId, out StatusNotificationRequest, OnException = null)

        /// <summary>
        /// Try to parse the given text representation of a StatusNotification request.
        /// </summary>
        /// <param name="Text">The text to be parsed.</param>
        /// <param name="RequestId">The request identification.</param>
        /// <param name="ChargeBoxId">The charge box identification.</param>
        /// <param name="StatusNotificationRequest">The parsed StatusNotification request.</param>
        /// <param name="OnException">An optional delegate called whenever an exception occured.</param>
        public static Boolean TryParse(String                         Text,
                                       Request_Id                     RequestId,
                                       ChargeBox_Id                   ChargeBoxId,
                                       out StatusNotificationRequest  StatusNotificationRequest,
                                       OnExceptionDelegate            OnException  = null)
        {

            try
            {

                Text = Text?.Trim();

                if (Text.IsNotNullOrEmpty())
                {

                    if (Text.StartsWith("{") &&
                        TryParse(JObject.Parse(Text),
                                 RequestId,
                                 ChargeBoxId,
                                 out StatusNotificationRequest,
                                 out String ErrorResponse))
                    {
                        return true;
                    }

                    if (TryParse(XDocument.Parse(Text).Root,
                                 RequestId,
                                 ChargeBoxId,
                                 out StatusNotificationRequest,
                                 OnException))
                    {
                        return true;
                    }

                }

            }
            catch (Exception e)
            {
                OnException?.Invoke(DateTime.UtcNow, Text, e);
            }

            StatusNotificationRequest = null;
            return false;

        }

        #endregion

        #region ToXML()

        /// <summary>
        /// Return a XML representation of this object.
        /// </summary>
        public XElement ToXML()

            => new XElement(OCPPNS.OCPPv1_6_CS + "statusNotificationRequest",

                   new XElement(OCPPNS.OCPPv1_6_CS + "connectorId",            ConnectorId.ToString()),
                   new XElement(OCPPNS.OCPPv1_6_CS + "status",                 Status.     AsText()),
                   new XElement(OCPPNS.OCPPv1_6_CS + "errorCode",              ErrorCode.  AsText()),

                   Info.IsNotNullOrEmpty()
                       ? new XElement(OCPPNS.OCPPv1_6_CS + "info",             Info)
                       : null,

                   StatusTimestamp.HasValue
                       ? new XElement(OCPPNS.OCPPv1_6_CS + "timestamp",        StatusTimestamp.Value.ToIso8601())
                       : null,

                   VendorId.IsNotNullOrEmpty()
                       ? new XElement(OCPPNS.OCPPv1_6_CS + "vendorId",         VendorId)
                       : null,

                   VendorErrorCode.IsNotNullOrEmpty()
                       ? new XElement(OCPPNS.OCPPv1_6_CS + "vendorErrorCode",  VendorErrorCode)
                       : null

               );

        #endregion

        #region ToJSON(CustomStatusNotificationRequestSerializer = null)

        /// <summary>
        /// Return a JSON representation of this object.
        /// </summary>
        /// <param name="CustomStatusNotificationRequestSerializer">A delegate to serialize custom StatusNotification requests.</param>
        public JObject ToJSON(CustomJObjectSerializerDelegate<StatusNotificationRequest> CustomStatusNotificationRequestSerializer = null)
        {

            var JSON = JSONObject.Create(

                           new JProperty("connectorId",             ConnectorId.ToString()),
                           new JProperty("status",                  Status.     AsText()),
                           new JProperty("errorCode",               ErrorCode.  AsText()),

                           Info.IsNotNullOrEmpty()
                               ? new JProperty("info",              Info)
                               : null,

                           StatusTimestamp.HasValue
                               ? new JProperty("timestamp",         StatusTimestamp.Value.ToIso8601())
                               : null,

                           VendorId.IsNotNullOrEmpty()
                               ? new JProperty("vendorId",          VendorId)
                               : null,

                           VendorErrorCode.IsNotNullOrEmpty()
                               ? new JProperty("vendorErrorCode",   VendorErrorCode)
                               : null);

            return CustomStatusNotificationRequestSerializer != null
                       ? CustomStatusNotificationRequestSerializer(this, JSON)
                       : JSON;

        }

        #endregion


        #region Operator overloading

        #region Operator == (StatusNotificationRequest1, StatusNotificationRequest2)

        /// <summary>
        /// Compares two StatusNotification requests for equality.
        /// </summary>
        /// <param name="StatusNotificationRequest1">A StatusNotification request.</param>
        /// <param name="StatusNotificationRequest2">Another StatusNotification request.</param>
        /// <returns>True if both match; False otherwise.</returns>
        public static Boolean operator == (StatusNotificationRequest StatusNotificationRequest1, StatusNotificationRequest StatusNotificationRequest2)
        {

            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(StatusNotificationRequest1, StatusNotificationRequest2))
                return true;

            // If one is null, but not both, return false.
            if ((StatusNotificationRequest1 is null) || (StatusNotificationRequest2 is null))
                return false;

            return StatusNotificationRequest1.Equals(StatusNotificationRequest2);

        }

        #endregion

        #region Operator != (StatusNotificationRequest1, StatusNotificationRequest2)

        /// <summary>
        /// Compares two StatusNotification requests for inequality.
        /// </summary>
        /// <param name="StatusNotificationRequest1">A StatusNotification request.</param>
        /// <param name="StatusNotificationRequest2">Another StatusNotification request.</param>
        /// <returns>False if both match; True otherwise.</returns>
        public static Boolean operator != (StatusNotificationRequest StatusNotificationRequest1, StatusNotificationRequest StatusNotificationRequest2)

            => !(StatusNotificationRequest1 == StatusNotificationRequest2);

        #endregion

        #endregion

        #region IEquatable<StatusNotificationRequest> Members

        #region Equals(Object)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="Object">An object to compare with.</param>
        /// <returns>true|false</returns>
        public override Boolean Equals(Object Object)
        {

            if (Object is null)
                return false;

            if (!(Object is StatusNotificationRequest StatusNotificationRequest))
                return false;

            return Equals(StatusNotificationRequest);

        }

        #endregion

        #region Equals(StatusNotificationRequest)

        /// <summary>
        /// Compares two StatusNotification requests for equality.
        /// </summary>
        /// <param name="StatusNotificationRequest">A StatusNotification request to compare with.</param>
        /// <returns>True if both match; False otherwise.</returns>
        public override Boolean Equals(StatusNotificationRequest StatusNotificationRequest)
        {

            if (StatusNotificationRequest is null)
                return false;

            return ConnectorId.    Equals(StatusNotificationRequest.ConnectorId) &&
                   Status.         Equals(StatusNotificationRequest.Status)      &&
                   ErrorCode.      Equals(StatusNotificationRequest.ErrorCode)   &&

                   Info.Equals(StatusNotificationRequest.Info) &&

                   ((!StatusTimestamp.HasValue && !StatusNotificationRequest.StatusTimestamp.HasValue) ||
                     (StatusTimestamp.HasValue && StatusNotificationRequest.StatusTimestamp.HasValue && StatusTimestamp.Value.Equals(StatusNotificationRequest.StatusTimestamp.Value))) &&

                   VendorId.       Equals(StatusNotificationRequest.VendorId)    &&
                   VendorErrorCode.Equals(StatusNotificationRequest.VendorErrorCode);

        }

        #endregion

        #endregion

        #region (override) GetHashCode()

        /// <summary>
        /// Return the HashCode of this object.
        /// </summary>
        /// <returns>The HashCode of this object.</returns>
        public override Int32 GetHashCode()
        {
            unchecked
            {

                return ConnectorId.GetHashCode() * 17 ^
                       Status.     GetHashCode() * 13 ^
                       ErrorCode.  GetHashCode() * 11 ^
                       Info.       GetHashCode() *  7 ^

                       (StatusTimestamp.HasValue
                            ? StatusTimestamp.GetHashCode()
                            : 0) * 19 ^

                       ErrorCode.  GetHashCode() *  5 ^
                       Info.       GetHashCode();

            }
        }

        #endregion

        #region (override) ToString()

        /// <summary>
        /// Return a text representation of this object.
        /// </summary>
        public override String ToString()

            => String.Concat(ConnectorId,
                             " / ", Status,
                             " / ", ErrorCode);

        #endregion

    }

}
