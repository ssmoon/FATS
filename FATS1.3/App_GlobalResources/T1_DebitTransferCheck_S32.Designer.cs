//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找已本地化的字符串等等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 Visual Studio 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class T1_DebitTransferCheck_S32 {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal T1_DebitTransferCheck_S32() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.T1_DebitTransferCheck_S32", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   为使用此强类型资源类的所有资源查找重写当前线程的 CurrentUICulture 
        /// 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 受理持票人兑付跨行转帐支票,必然采用[存放中央银行款项]和[其他应付款] 的本地化字符串。
        /// </summary>
        internal static string 一级科目填写提示 {
            get {
                return ResourceManager.GetString("一级科目填写提示", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 资产增加在借方,资产减少在贷方；负债减少在借方,负债增加在贷方 的本地化字符串。
        /// </summary>
        internal static string 借贷方向填写提示 {
            get {
                return ResourceManager.GetString("借贷方向填写提示", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 本业务中,受理行[存放中央银行款项]是减少的情形,[其他应付款]是增加的情形 的本地化字符串。
        /// </summary>
        internal static string 增减变化填写提示 {
            get {
                return ResourceManager.GetString("增减变化填写提示", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 对于[存放中央银行款项]，存放中央银行款项的帐户是3421,因此,二级科目是3421; 对于[其他应付款]，支票中,付款行写明是同城其他银行,因此,用[同城交换暂收款项] 的本地化字符串。
        /// </summary>
        internal static string 子级科目填写提示 {
            get {
                return ResourceManager.GetString("子级科目填写提示", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 [存放中央银行款项]是资产类帐户,[其他应付款]是负债类账户 的本地化字符串。
        /// </summary>
        internal static string 科目类型填写提示 {
            get {
                return ResourceManager.GetString("科目类型填写提示", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 转帐支票上,[人民币项]已标明金额 的本地化字符串。
        /// </summary>
        internal static string 科目金额填写提示 {
            get {
                return ResourceManager.GetString("科目金额填写提示", resourceCulture);
            }
        }
    }
}
