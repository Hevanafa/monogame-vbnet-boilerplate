Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Game1
    Inherits Game

    Private gdm As GraphicsDeviceManager
    Private mainSB As SpriteBatch
    Private box As Texture2D

    Private pos As Vector2

    Public Sub New()
        gdm = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Contents"
        IsMouseVisible = True
    End Sub


    Protected Overrides Sub Initialize()
        ' Todo: Add your initialisation logic here

        MyBase.Initialize()
    End Sub


    Protected Overrides Sub LoadContent()
        mainSB = New SpriteBatch(GraphicsDevice)

        ' by Limezu: https://limezu.itch.io/modernexteriors
        box = Content.Load(Of Texture2D)("box")
    End Sub


    Function ScreenWidth%()
        ScreenWidth = GraphicsDevice.Viewport.Width
    End Function


    Function ScreenHeight%()
        ScreenHeight = GraphicsDevice.Viewport.Height
    End Function


    Protected Overrides Sub Update(gameTime As GameTime)

        Dim kbstate = Keyboard.GetState

        ' Todo: Your update code here

        If kbstate.IsKeyDown(Keys.Escape) Then _
            [Exit]()

        If kbstate.IsKeyDown(Keys.Left) Then _
            pos.X -= 5

        If kbstate.IsKeyDown(Keys.Right) Then _
            pos.X += 5

        If kbstate.IsKeyDown(Keys.Up) Then _
            pos.Y -= 5

        If kbstate.IsKeyDown(Keys.Down) Then _
            pos.Y += 5


        ' Check bounds
        If pos.X < 0 Then pos.X = 0
        If pos.X > ScreenWidth() - box.Width Then pos.X = ScreenWidth() - box.Width

        If pos.Y < 0 Then pos.Y = 0
        If pos.Y > ScreenHeight() - box.Height Then pos.Y = ScreenHeight() - box.Height


        MyBase.Update(gameTime)
    End Sub

    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.CornflowerBlue)

        ' Todo: Your drawing code here

        mainSB.Begin()

        mainSB.Draw(box, pos, Color.White)

        mainSB.End()

        MyBase.Draw(gameTime)
    End Sub


End Class
