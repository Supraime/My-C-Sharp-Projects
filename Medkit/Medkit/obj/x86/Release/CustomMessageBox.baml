   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MedkitMedkit      Medkit.CustomMessageBox   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   localclr-namespace:Medkit  -     � Title$  CustomMessageBox��$	��145��$	��500�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� .+��� $��40��$	��Top=����	#FF2D9C5F� $��40��$	��Top=�.+���  �� Orientation$ 
Horizontal=�$
��Left=�$��10,0,0,0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ MessageAlert=�
�������$��Center=�$��Center=��� -    ��Name$ 
titleLabel��$+��%/Medkit;component/Fonts/#Roboto Black)�$��14(�$��Center=�$
��Left=�
�������.��
MessageBox� -    �Name$ 	adaptMenu��$	��500��$��0q�$��Center=�$��Bottom=�$	��115�� � RowDefinitions �� $	��12* ��� $	��11* �	 � ColumnDefinitions	 �� $	��19* ��� $	��12* ��� $	��19* �.+��� -   $ messageLabel��$��Center=�$��Center=�$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��0,23,0,0q�$��3��.��MessageText�� -   
 ��Name$
 buttonOk�� �� IsCancel . $y�Hidden=�$
��Ок��
�������$��Center=�$��0q�$��Center=�$	��102��$%��/Medkit;component/Fonts/#Roboto)�$��1��$��1�� "  MaterialDesignRaisedDarkButton#��[  �� -   $
 	buttonYes�� �� 	IsDefault . $y�Hidden=�$��1��$��Подтвердить��$%��/Medkit;component/Fonts/#Roboto)����	#DDFFFFFF$��0q�$��Center=�#��[  �� -   $
 buttonNo�� . $y�Hidden=�$��1��$��3��$��Отмена��$%��/Medkit;component/Fonts/#Roboto)����	#DDFFFFFF$��0q�$��Center=�#��[  