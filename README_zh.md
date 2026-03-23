[繁體中文](./README_zh.md) | [日本語](./README.md)
# POOL LOOP
## 作品概要 | Project Overview
POOL LOOP 是一項體驗型互動裝置，旨在探討在資訊爆炸的時代中，「無用資訊」如何成為社會噪音，以及這些資訊如何獲得再生的可能。
> [!NOTE]
> **製作時間**：2023年10月 - 2023年12月（約3個月）<br>
**團隊組成**：4位<br>
**負責部分**：主程式（Unity）、系統架構設計、硬體控制邏輯（Raspberry Pi）。<br>
**主要技術**：Unity, C#, Firebase, p5.js, Raspberry Pi, TextMesh Pro<br>
**作品種類**：互動裝置
## 作品理念 | Concept
我們身在資訊爆炸的世代，每天都在接收大量的資訊。然而其中有許多資訊對我們來說都是無用的。這些資訊大量的存在於網路，成為資訊垃圾無法發揮實質效益。既然現實生活中的垃圾都能回收再利用，那麼資訊垃圾是否也能夠被回收再利用？<br>
因此我們以資訊、回收、能量循環三種元素作為創作主軸，希望能藉由這件作品表達能源再利用的理念，也象徵著點亮資訊再生的機會。<br>
本作品針對以下三個關鍵字進行探討：
  - 資訊爆炸、過度攝取
  - 數位回收
  - 能源可視化
## demo影片 | Demo Video
[互動流程](https://www.youtube.com/watch?v=IEYAUWUUYmQ)
## 系統架構 | System Architecture
這是一項整合了 Web 前端、即時資料庫、遊戲引擎與硬體設備的跨平台系統。<br>
<img width="1051" height="580" alt="截圖 2026-03-23 下午5 42 24" src="https://github.com/user-attachments/assets/61d7cf56-cdea-4734-bb09-3638ec516cec" />
#### 互動流程
1. **Web**：觀眾點擊由 p5.js 建構的假新聞網站上的「刪除」按鈕。
2. **Data Relay**：訊號透過 Firebase Realtime Database 進行即時傳輸。
3. **Unity**：Unity 側接收到刪除訊號後，利用物理引擎使「文字方塊」在畫面中落下並堆積。
4. **Hardware**：當觀眾轉動回收箱的把手時，Raspberry Pi（透過三軸加速度感測器）會偵測到動作，並經由 Firebase 開啟 Unity 內的「門」。
5. **Feedback**：隨著文字方塊落下，實體燈泡也會同步點亮，藉此表現資訊的能量轉換。
## 技術問題與解決方法 | Key Challenges
- **動態跨平台通訊**<br>
  以 Firebase Realtime Database 為核心，實現了 Web (p5.js)、遊戲引擎 (Unity) 與硬體 (Raspberry Pi) 等不同平台間的資料通訊。
- **繁體中文字體渲染優化**<br>
  為了克服 Unity 在繁體中文顯示上的限制，導入了 TextMesh Pro 並透過自定義字型資產管理，在維持美學表現的同時確保了文字的呈現。
- **3D 物理物件的視覺控制**<br>
  為了在方塊的六個面上準確映射文字，自行撰寫了 C# 腳本，透過計算各個面的法線方向，動態修正文字的面向。<br>
  藉此，即使在伴隨物理行為的物件上，也能實現高辨識度的文字顯示。
## 負責部分
- **創作發想**：撰寫創作理念及設計互動流程。
- **Unity專案開發**：C# 腳本實作（Firebase 同步邏輯、物理運算、文字生成）。。
- **硬體連動設計**:感測器與軟體間的通訊程式及裝置測試。
## demo畫面
<p align="center">
<img src="https://github.com/user-attachments/assets/7a3004b9-28b6-4b6c-a0a7-70c6c0b5e8aa" width="45%"/>
<img src="https://github.com/user-attachments/assets/a038bae9-05a2-4dae-ba58-fc9d104254ba" width="45%" />
</p>
