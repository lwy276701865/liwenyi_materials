// pages/page1/page1.js
//var src='';
//var imgIsHide="true";
Page({
  /**
   * 页面的初始数据
   */
  data: {
    //test:null
    cameraIsHidden: true,
    imgIsHide: true,
    imgFilePath: ""
  },
  chooseImage_click(e) {
    var that = this;
    wx.chooseImage({
      count: 1, // 默认9
      sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有
      sourceType: ['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有
      success: function (res) {
        var filePath = res.tempFilePaths[0];
        that.setData({
          imgFilePath: filePath,
          //src: res.tempFilePaths
          imgIsHide: false
        });
      },
      fail: function (error) {
        console.error("调用本地相册文件时出错")
        console.warn(error)
      },
      complete: function () {
      }
    });
  },

  takePhoto_click(e) {
    const ctx = wx.createCameraContext()
    ctx.takePhoto({
      quality: 'high',
      success: (res) => {
        var filePath = res.tempImagePath;
        this.setData({
          imgFilePath:filePath,
          cameraIsHidden: false,
          imgIsHide: false   
        });
      },
      fail: function (error) {
        console.error("调用相机时出错")
        console.warn(error)
      }
    });
  },



  // choose_click(e) {
  //   wx.showActionSheet({
  //     itemList: ['从手机相册选择', '拍照'],
  //     success: function (res) {
  //       //console.log(res.tapIndex)

  //       if (res.tapIndex == 0) {
  //         bindViewTap:function()
  //         {
  //           var that = this;
  //           wx.chooseImage({
  //             count: 1, // 默认9
  //             sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有
  //             sourceType: ['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有
  //             success(res) {
  //               var src = res.tempFilePaths[0];
  //               that.setData({
  //                 imgFilePath: src,
  //                 imgIsHide: false
  //               });
  //             },
  //             fail: function (error) {
  //               console.error("调用本地相册文件时出错")
  //               console.warn(error)
  //             },
  //             complete: function () {
  //             }
  //           });
  //         }
          
  //       }

  //       else if (res.tapIndex == 1) {
  //         let ctx = wx.createCameraContext();
  //         ctx.takePhoto({
  //           quality: 'high',
  //           success: (res) => {
  //             src = res.tempImagePath;
  //             // this.setData({
  //             //   imgFilePath: filePath,
  //             //   cameraIsHidden: false,
  //             //   imgIsHide: false
  //             // });
  //           },
  //         });
  //       };

  //     },
  //     fail: function (res) {
  //       console.log(res.errMsg)
  //     }
  //   });
  // },



  /*error(e) {
    console.log(e.detail)
  },*/

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})