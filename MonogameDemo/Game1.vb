Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Game1
    Inherits Game

    Private _graphics As GraphicsDeviceManager
    Private _spriteBatch As SpriteBatch
    Private _texture As Texture2D

    Private _pos As Vector2

    Public Sub New()
        _graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Contents"
        IsMouseVisible = True
    End Sub


    Protected Overrides Sub Initialize()
        ' Todo: Add your initialisation logic here

        MyBase.Initialize()
    End Sub


    Protected Overrides Sub LoadContent()
        _spriteBatch = New SpriteBatch(GraphicsDevice)
        _texture = Content.Load(Of Texture2D)("b2.png")
    End Sub


    Protected Overrides Sub Update(gameTime As GameTime)

        Dim kbstate = Keyboard.GetState

        ' Todo: Your update code here
        If kbstate.IsKeyDown(Keys.Escape) Then _
            Me.Exit()

        If kbstate.IsKeyDown(Keys.Left) Then
            _pos.X -= 5
        End If

        If kbstate.IsKeyDown(Keys.Right) Then
            _pos.X += 5
        End If

        If kbstate.IsKeyDown(Keys.Up) Then
            _pos.Y -= 5
        End If

        If kbstate.IsKeyDown(Keys.Down) Then
            _pos.Y += 5
        End If

        MyBase.Update(gameTime)
    End Sub

    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.CornflowerBlue)

        ' Todo: Your drawing code here
        _spriteBatch.Begin()

        _spriteBatch.Draw(_texture, _pos, Color.White)

        _spriteBatch.End()

        MyBase.Draw(gameTime)
    End Sub


End Class
