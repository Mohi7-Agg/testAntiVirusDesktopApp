   M S B A M L   `   `   `  ����R  NtestAntiVirusDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:testAntiVirusDesktopApptestAntiVirusDesktopApp  5   	   (    "testAntiVirusDesktopApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;	viewmodel%clr-namespace:testAntiVirusDesktopApp     5   	     � Title$  Test Anti Virus Status��5   	   $	��350��6(   $	��525��65    � 	Resources 5	      '   !testAntiVirusDesktopApp.ViewModel   	ViewModel��%   &	          5
   
   6   5      .��5      �  � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $,��&Click Submit to know Anti Virus Status��61   $��Center=�6_   �� 5   
   $��Submit��6   $��Right=�6D   $��0��6`   $��1��6m   ��6"   �� *SubmitCommand+6m   �� 5   
   $��1��6   $��0��6!   $��Center=�61   ��6N   �� *SystemInfo.Result+ �� Mode$ TwoWay=�5      5      