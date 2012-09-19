using System;
namespace Hch.iDisk.Model
{
	/// <summary>
	/// Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin
	{
		public Admin()
		{}
		#region Model
		private int _userid;
		/// <summary>
		/// 
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

