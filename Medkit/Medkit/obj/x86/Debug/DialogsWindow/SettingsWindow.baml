   M S B A M L   `   `   `  ����A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  5   	   )    #Medkit.DialogsWindow.SettingsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Medkit.DialogsWindow     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  SettingsWindow��5	   	   $	��250��6    $	��550��6-    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��329* �6   �� 5      $
��171* �6    � RowDefinitions 5   
   �� 5      $	��43* �6   �� 5      $	��42* �6   �� 5      $	��74* �6   �� 5      $	��37* �6   �� 5      $	��46* �6   .+�5   
   �� ���	#FF388E3C$��2��6%   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��2��6;   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Cog=�5      $��32��5      
�������$��32��5!      $��Center=�5"      �� 5#      $+��%/Medkit;component/Fonts/#Roboto Black)�6   $��16(�6G   $
��Left=�6U   $��Center=�6p   
�������$
��Bold"�6�   .��6�   Настройки6�   5$      �� 5%   
    �� IsCancel . $��4��6!    "  MaterialDesignRaisedDarkButton#��[  6.   $��	10,6,10,8q�6f   $��16(�6y   $%��/Medkit;component/Fonts/#Roboto)�6�   $��Center=�6�   $��2��6�   .��6�   Закрыть6�   �� 5&   
   $��0��6   $��Center=�6    $��	10,11,0,5q�6;   $%��/Medkit;component/Fonts/#Roboto)�6N   $��14(�6{   $
��Bold"�6�   $��1��6�   $��26��6�   .��6�   PNПоследние копирование базы производилось:6�   �� 5'   
   -   5        	 ��Name$	 	TimeLabel��5'      $��1��6#   $��1��60   $%��/Medkit;component/Fonts/#Roboto)�6@   $��14(�6m   $��Center=�6{   $��0,11,0,5q�6�   $��26��6�   .��6�   5 дней назад6�   � 5(   
   $��3��6   $��2��6    5)      �� 5*      �� 5+      .+�5-      �� -   5        #��[  5-   +   $
��10,0q�6c   $��16(�6q   $%��/Medkit;component/Fonts/#Roboto)�6   $	��Top=�6�   $��0��6�   .��6�   *(Ручное копирование БД6�   �� 5.      -   5        #��[  5.   0   $
��10,0q�6h   $��16(�6v   $%��/Medkit;component/Fonts/#Roboto)�6�   $	��Top=�6�   $��1��6�   .��6�   Востановить БД6�   5/      '  !MaterialDesignThemes.Wpf.Snackbar  50   
   -   5        
  Name$
 	SnackInfo��50   C   $��2��6"   $��2��6/   $��
26,0,24,10q�6�   $	��500��6�      MessageQueue 6V   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6�   51      52      