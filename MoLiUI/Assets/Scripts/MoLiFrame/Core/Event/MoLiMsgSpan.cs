using UnityEngine;
using System.Collections;

public class MoLiMsgSpan {
	public const int Count = 3000;
}

public enum QMgrID
{
	Game = 0,

	UI = MoLiMsgSpan.Count, 			// 3000
	Sound = MoLiMsgSpan.Count * 2,		// 6000

	NPCManager = MoLiMsgSpan.Count * 3,//9000

	CharactorManager = MoLiMsgSpan.Count * 4,//12000

	AB = MoLiMsgSpan.Count * 5,//15000

	NetManager = MoLiMsgSpan.Count * 6,//18000

}
