using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime;
using System.Runtime.Serialization;

namespace iDiskClient.UC
{
    class ListViewItem:System.Windows.Forms.ListViewItem
    {
        // 摘要:
        //     使用默认值初始化 System.Windows.Forms.ListViewItem 类的新实例。
        public ListViewItem() : base() { }
        //
        // 摘要:
        //     初始化 System.Windows.Forms.ListViewItem 类的新实例，并将它分配到指定的组。
        //
        // 参数:
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(System.Windows.Forms.ListViewGroup group)
            : base(group) { }
        //
        // 摘要:
        //     用指定的项文本初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   text:
        //     要为该项显示的文本。该文本不应该超过 259 个字符。
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public ListViewItem(string text)
            : base(text) { }
        //
        // 摘要:
        //     用表示子项的字符串数组初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   items:
        //     表示此新项的子项的字符串数组。
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public ListViewItem(string[] items)
            : base(items) { }
        //
        // 摘要:
        //     用项图标的图像索引位置和 System.Windows.Forms.ListViewItem.ListViewSubItem 对象的数组初始化 System.Windows.Forms.ListViewItem
        //     类的新实例。
        //
        // 参数:
        //   subItems:
        //     System.Windows.Forms.ListViewItem.ListViewSubItem 类型的数组，表示该项的子项。
        //
        //   imageIndex:
        //     图像的从零开始的索引，该图像位于与包含该项的 System.Windows.Forms.ListView 关联的 System.Windows.Forms.ImageList
        //     中。
        public ListViewItem(ListViewItem.ListViewSubItem[] subItems, int imageIndex)
            : base(subItems, imageIndex) { }
        //
        // 摘要:
        //     用指定的子项和图像初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   subItems:
        //     System.Windows.Forms.ListViewItem.ListViewSubItem 对象的数组。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在 System.Windows.Forms.ListViewItem 中显示该名称。
        public ListViewItem(ListViewItem.ListViewSubItem[] subItems, string imageKey)
            : base(subItems, imageKey) { }
        //
        // 摘要:
        //     使用指定的序列化信息和流上下文初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   info:
        //     一个 System.Runtime.Serialization.SerializationInfo，包含关于要初始化的 System.Windows.Forms.ListViewItem
        //     的信息。
        //
        //   context:
        //     一个 System.Runtime.Serialization.StreamingContext，指示序列化的流的源和目标以及上下文信息。
        protected ListViewItem(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
        //
        // 摘要:
        //     用指定的项文本和项图标的图像索引位置初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   text:
        //     要为该项显示的文本。该文本不应该超过 259 个字符。
        //
        //   imageIndex:
        //     图像在与包含该项的 System.Windows.Forms.ListView 关联的 System.Windows.Forms.ImageList
        //     内的索引（从零开始）。
        public ListViewItem(string text, int imageIndex)
            : base(text, imageIndex) { }
        //
        // 摘要:
        //     用指定的项文本初始化 System.Windows.Forms.ListViewItem 类的新实例，并将它分配到指定的组。
        //
        // 参数:
        //   text:
        //     要为该项显示的文本。该文本不应该超过 259 个字符。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(string text, System.Windows.Forms.ListViewGroup group)
            : base(text, group) { }
        //
        // 摘要:
        //     用指定的文本和图像初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   text:
        //     要为该项显示的文本。该文本不应该超过 259 个字符。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在 System.Windows.Forms.ListViewItem 中显示该名称。
        public ListViewItem(string text, string imageKey)
            : base(text, imageKey) { }
        //
        // 摘要:
        //     用项图标的图像索引位置和表示子项的字符串数组初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   items:
        //     表示此新项的子项的字符串数组。
        //
        //   imageIndex:
        //     图像在与包含该项的 System.Windows.Forms.ListView 关联的 System.Windows.Forms.ImageList
        //     内的索引（从零开始）。
        public ListViewItem(string[] items, int imageIndex)
            : base(items, imageIndex) { }
        //
        // 摘要:
        //     用表示子项的字符串数组初始化 System.Windows.Forms.ListViewItem 类的新实例，并将该项分配到指定的组。
        //
        // 参数:
        //   items:
        //     表示此新项的子项的字符串数组。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(string[] items, System.Windows.Forms.ListViewGroup group)
            : base(items, group) { }
        //
        // 摘要:
        //     用指定的项和子项文本及图像初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   items:
        //     一个数组，它包含 System.Windows.Forms.ListViewItem 的子项的文本。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在 System.Windows.Forms.ListViewItem 中显示该名称。
        public ListViewItem(string[] items, string imageKey)
            : base(items, imageKey) { }
        //
        // 摘要:
        //     用项图标的图像索引位置和 System.Windows.Forms.ListViewItem.ListViewSubItem 对象的数组初始化 System.Windows.Forms.ListViewItem
        //     类的新实例，并将该项分配到指定的组。
        //
        // 参数:
        //   subItems:
        //     System.Windows.Forms.ListViewItem.ListViewSubItem 类型的数组，表示该项的子项。
        //
        //   imageIndex:
        //     图像的从零开始的索引，该图像位于与包含该项的 System.Windows.Forms.ListView 关联的 System.Windows.Forms.ImageList
        //     中。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(ListViewItem.ListViewSubItem[] subItems, int imageIndex, System.Windows.Forms.ListViewGroup group)
            : base(subItems, imageIndex, group) { }
        //
        // 摘要:
        //     用指定的子项、图像和组初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   subItems:
        //     System.Windows.Forms.ListViewItem.ListViewSubItem 对象的数组，表示 System.Windows.Forms.ListViewItem
        //     的子项。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在该项中显示该名称。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(ListViewItem.ListViewSubItem[] subItems, string imageKey, System.Windows.Forms.ListViewGroup group)
            : base(subItems, imageKey, group) { }
        //
        // 摘要:
        //     用指定的项文本和项图标的图像索引位置初始化 System.Windows.Forms.ListViewItem 类的新实例，并将该项分配到指定的组。
        //
        // 参数:
        //   text:
        //     要为该项显示的文本。该文本不应该超过 259 个字符。
        //
        //   imageIndex:
        //     图像的从零开始的索引，该图像位于与包含该项的 System.Windows.Forms.ListView 关联的 System.Windows.Forms.ImageList
        //     中。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(string text, int imageIndex, System.Windows.Forms.ListViewGroup group)
            : base(text, imageIndex, group) { }
        //
        // 摘要:
        //     用指定的文本、图像和组初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   text:
        //     要为该项显示的文本。该文本不应该超过 259 个字符。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在该项中显示该名称。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(string text, string imageKey, System.Windows.Forms.ListViewGroup group)
            : base(text, imageKey, group) { }
        //
        // 摘要:
        //     用项图标的图像索引位置和表示子项的字符串数组初始化 System.Windows.Forms.ListViewItem 类的新实例，并将该项分配到指定的组。
        //
        // 参数:
        //   items:
        //     表示此新项的子项的字符串数组。
        //
        //   imageIndex:
        //     图像的从零开始的索引，该图像位于与包含该项的 System.Windows.Forms.ListView 关联的 System.Windows.Forms.ImageList
        //     中。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(string[] items, int imageIndex, System.Windows.Forms.ListViewGroup group)
            : base(items, imageIndex, group) { }
        //
        // 摘要:
        //     用包含指定文本、图像和组的子项初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   items:
        //     一个字符串数组，表示 System.Windows.Forms.ListViewItem 的子项的文本。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在该项中显示该名称。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(string[] items, string imageKey, System.Windows.Forms.ListViewGroup group)
            : base(items,imageKey,group) { }
        //
        // 摘要:
        //     用项图标的图像索引位置、前景色、背景色、项的字体和表示子项的字符串数组初始化 System.Windows.Forms.ListViewItem
        //     类的新实例。
        //
        // 参数:
        //   items:
        //     表示此新项的子项的字符串数组。
        //
        //   imageIndex:
        //     图像的从零开始的索引，该图像位于与包含该项的 System.Windows.Forms.ListView 关联的 System.Windows.Forms.ImageList
        //     中。
        //
        //   foreColor:
        //     System.Drawing.Color，表示该项的前景色。
        //
        //   backColor:
        //     System.Drawing.Color，表示该项的背景色。
        //
        //   font:
        //     System.Drawing.Font，表示用于显示该项文本的字体。
        public ListViewItem(string[] items, int imageIndex, Color foreColor, Color backColor, Font font)
            : base(items,imageIndex,foreColor,backColor,font) { }
        //
        // 摘要:
        //     用包含指定的文本、图像、颜色和字体的子项初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   items:
        //     一个字符串数组，表示 System.Windows.Forms.ListViewItem 的子项的文本。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在该项中显示该名称。
        //
        //   foreColor:
        //     System.Drawing.Color，表示该项的前景色。
        //
        //   backColor:
        //     System.Drawing.Color，表示该项的背景色。
        //
        //   font:
        //     要应用于项文本的 System.Drawing.Font。
        public ListViewItem(string[] items, string imageKey, Color foreColor, Color backColor, Font font)
            : base(items, imageKey,foreColor,backColor,font) { }
        //
        // 摘要:
        //     用项图标的图像索引位置、前景色、背景色、项的字体和表示子项的字符串数组初始化 System.Windows.Forms.ListViewItem
        //     类的新实例。将该项分配到指定的组。
        //
        // 参数:
        //   items:
        //     表示此新项的子项的字符串数组。
        //
        //   imageIndex:
        //     图像的从零开始的索引，该图像位于与包含该项的 System.Windows.Forms.ListView 关联的 System.Windows.Forms.ImageList
        //     中。
        //
        //   foreColor:
        //     System.Drawing.Color，表示该项的前景色。
        //
        //   backColor:
        //     System.Drawing.Color，表示该项的背景色。
        //
        //   font:
        //     System.Drawing.Font，表示用于显示该项文本的字体。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(string[] items, int imageIndex, Color foreColor, Color backColor, Font font, System.Windows.Forms.ListViewGroup group)
            :base(items, imageIndex,  foreColor,  backColor,  font,  group){ }
        //
        // 摘要:
        //     用包含指定的文本、图像、颜色、字体和组的子项初始化 System.Windows.Forms.ListViewItem 类的新实例。
        //
        // 参数:
        //   items:
        //     一个字符串数组，表示 System.Windows.Forms.ListViewItem 的子项的文本。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在该项中显示该名称。
        //
        //   foreColor:
        //     System.Drawing.Color，表示该项的前景色。
        //
        //   backColor:
        //     System.Drawing.Color，表示该项的背景色。
        //
        //   font:
        //     要应用于项文本的 System.Drawing.Font。
        //
        //   group:
        //     要将项分配到的 System.Windows.Forms.ListViewGroup。
        public ListViewItem(string[] items, string imageKey, Color foreColor, Color backColor, Font font, System.Windows.Forms.ListViewGroup group)
            : base(items,  imageKey,  foreColor,  backColor,  font, group) { }
        //
        // 摘要:
        //     用包含指定的文本、关联的值初始化UC.ListViewItem 类的新实例。
        //
        // 参数:
        //   items:
        //     一个字符串数组，表示 System.Windows.Forms.ListViewItem 的子项的文本。
        //
        //   imageKey:
        //     所属 System.Windows.Forms.ListView 的 System.Windows.Forms.ListViewItem.ImageList
        //     中的图像的名称，将在该项中显示该名称。
        public ListViewItem(string text, object value)
            : base(text)
        {
            Value = value;
        }
        /// <summary>
        /// 获取或设置此ListViewItem关联的值
        /// </summary>
        public object Value { get; set; }

    }
}
