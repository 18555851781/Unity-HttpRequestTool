﻿
using System.Collections.Generic;




namespace Z.Network
{
    /// <summary>
    /// HTTP数据包基础类
    /// </summary>
    public abstract class HTTPPacketAck
    {
		// public HTTPPacketHead header;	//the header of the packet
		public int code;
		public string desc;
		public int time;

        public HTTPPacketAck()
        {
        }
    }

	/// <summary>
	/// HTTP packet head.
	/// </summary>
	public class HTTPPacketHead
	{
		public int code;
		public string desc;
	}

//    /// <summary>
//    /// 数据包工厂
//    /// </summary>
//    public abstract class HTTPPacketFactory
//    {
//        public abstract HTTPPacketAck Create(JSONNode json);    //创建包
//        public abstract string GetPacketAction();  //获取包Action
//    }


}