﻿Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.ApplicationModel
Imports Windows.ApplicationModel.Activation
Imports Windows.Foundation
Imports Windows.Foundation.Collections
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Navigation

Namespace PieChart
    ''' <summary>
    ''' Provides application-specific behavior to supplement the default Application class.
    ''' </summary>
    NotInheritable Partial Class App
        Inherits Application

        ''' <summary>
        ''' Initializes the singleton application object.  This is the first line of authored code
        ''' executed, and as such is the logical equivalent of main() or WinMain().
        ''' </summary>
        Public Sub New()
            Me.InitializeComponent()
            AddHandler Me.Suspending, AddressOf OnSuspending
        End Sub

        ''' <summary>
        ''' Invoked when the application is launched normally by the end user.  Other entry points
        ''' will be used such as when the application is launched to open a specific file.
        ''' </summary>
        ''' <param name="e">Details about the launch request and process.</param>
        Protected Overrides Sub OnLaunched(ByVal e As LaunchActivatedEventArgs)
#If DEBUG Then
            If System.Diagnostics.Debugger.IsAttached Then
                Me.DebugSettings.EnableFrameRateCounter = True
            End If
#End If
            Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

            ' Do not repeat app initialization when the Window already has content,
            ' just ensure that the window is active
            If rootFrame Is Nothing Then
                ' Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = New Frame()

                AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed

                If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                    'TODO: Load state from previously suspended application
                End If

                ' Place the frame in the current Window
                Window.Current.Content = rootFrame
            End If

            If e.PrelaunchActivated = False Then
                If rootFrame.Content Is Nothing Then
                    ' When the navigation stack isn't restored navigate to the first page,
                    ' configuring the new page by passing required information as a navigation
                    ' parameter
                    rootFrame.Navigate(GetType(MainPage), e.Arguments)
                End If
                ' Ensure the current window is active
                Window.Current.Activate()
            End If
        End Sub

        ''' <summary>
        ''' Invoked when Navigation to a certain page fails
        ''' </summary>
        ''' <param name="sender">The Frame which failed navigation</param>
        ''' <param name="e">Details about the navigation failure</param>
        Private Sub OnNavigationFailed(ByVal sender As Object, ByVal e As NavigationFailedEventArgs)
            Throw New Exception("Failed to load Page " & e.SourcePageType.FullName)
        End Sub

        ''' <summary>
        ''' Invoked when application execution is being suspended.  Application state is saved
        ''' without knowing whether the application will be terminated or resumed with the contents
        ''' of memory still intact.
        ''' </summary>
        ''' <param name="sender">The source of the suspend request.</param>
        ''' <param name="e">Details about the suspend request.</param>
        Private Sub OnSuspending(ByVal sender As Object, ByVal e As SuspendingEventArgs)
            Dim deferral = e.SuspendingOperation.GetDeferral()
            'TODO: Save application state and stop any background activity
            deferral.Complete()
        End Sub
    End Class
End Namespace
