Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Game1
    Inherits Game

    Private gdm As GraphicsDeviceManager
    Private mainSB As SpriteBatch
    Private box As Texture2D
    Private logo As Texture2D

    Private pos As Vector2
    Private font As SpriteFont

    Public Sub New()
        gdm = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Contents"
        IsMouseVisible = True
    End Sub


    Protected Overrides Sub Initialize()
        ' Todo: Add your initialisation logic here

        pos = New Vector2(100, 100)

        MyBase.Initialize()
    End Sub


    Protected Overrides Sub LoadContent()
        mainSB = New SpriteBatch(GraphicsDevice)

        ' by Limezu: https://limezu.itch.io/modernexteriors
        box = Content.Load(Of Texture2D)("box")

        logo = Content.Load(Of Texture2D)("monogame_logo")

        font = Content.Load(Of SpriteFont)("sample_font")
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

        mainSB.Draw(logo, New Vector2((ScreenWidth() - logo.Width) / 2, (ScreenHeight() - logo.Height) / 2), Color.White)

        mainSB.Draw(box, pos, Color.White)

        mainSB.DrawString(font, "MonoGame Boilerplate", Vector2.Zero, Color.White)
        mainSB.DrawString(font, $"Pos: {pos.X} {pos.Y}", New Vector2(0, 20), Color.White)

        mainSB.End()

        MyBase.Draw(gameTime)
    End Sub


End Class
