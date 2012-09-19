using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Serialization;

namespace iDiskClient.UC
{
    /// <summary>
    /// 自定义控件，添加Value字段
    /// 作者：黄昌湖
    /// 日期：2011-07-11
    /// </summary>
    class TreeNode:System.Windows.Forms.TreeNode
    {
        public TreeNode() : base() { }
        public TreeNode(string text) : base(text) { }
        public TreeNode(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }
        public TreeNode(string text, iDiskClient.UC.TreeNode[] children) : base(text, children) { }
        public TreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex) { }
        public TreeNode(string text, int imageIndex, int selectedImageIndex, iDiskClient.UC.TreeNode[] children)
            : base(text,imageIndex, selectedImageIndex, children) { }
        public TreeNode(string text, object value)
            : base(text)
        {
            Value = value;
        }
        public object Value { get; set; }
        
    }
}
