using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


using HTTP_ON_DATAERROR = System.Action<string,System.Action,System.Action>;




namespace MoLiFrame.Network
{

    /// <summary>
    /// HTTP会话
    /// </summary>
    public class HTTPSession
    {
        private string m_strURL = "";   //主地址

		public HTTP_ON_DATAERROR onDataError = null;
		public Hashtable m_cHeader = null;

        public HTTPSession(string url)
        {
            this.m_strURL = url;
        }

        /// <summary>
        /// Sends the GET data.
        /// </summary>
        /// <param name="packet">Packet.</param>
        /// <param name="callback">Callback.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
		public void SendGET<T>(HTTPPacketRequest packet ,System.Action<T>  callback = null, IHttpSession.PROCESS_HANDLE process = null) where T : HTTPPacketAck
        {
			HTTPLoader.GoWWW<T>(this.m_strURL + packet.GetAction() + packet.ToParam() , null , null , this.m_cHeader , onDataError , callback);
        }

		public void ReqestGET(HTTPPacketRequest packet ,System.Action<string>  callback = null, IHttpSession.PROCESS_HANDLE process = null) 
		{
			HTTPLoader.GoWWW(this.m_strURL + packet.GetAction() + packet.ToParam() , null , null , this.m_cHeader , onDataError , callback);
		}


		/// <summary>
		/// Post the specified packet and callback.
		/// </summary>
		/// <param name="packet">Packet.</param>
		/// <param name="callback">Callback.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void SendPOST<T>(HTTPPacketRequest packet ,System.Action<T> callback = null, IHttpSession.PROCESS_HANDLE process = null) where T : HTTPPacketAck
		{
			HTTPLoader.GoWWW<T>(this.m_strURL + packet.GetAction(), packet.ToForm() , null , this.m_cHeader , onDataError , callback);
		}

		/// <summary>
		/// Sends the Bytes Data.
		/// </summary>
		/// <param name="packet">Packet.</param>
		/// <param name="callback">Callback.</param>
		/// <param name="headers">Headers.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void SendBYTE<T>(HTTPPacketRequest packet ,System.Action<T> callback = null, IHttpSession.PROCESS_HANDLE process = null) where T : HTTPPacketAck
		{
			HTTPLoader.GoWWW<T>(this.m_strURL + packet.GetAction(), null , packet.ToMsgPacketByte() , this.m_cHeader , onDataError , callback);
		}
    }


}