   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  $    Medkit.DialogsWindow.AddClient   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Medkit.DialogsWindow     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  	AddClient��$	��500��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=�.���  � ColumnDefinitions �� ��  � RowDefinitions �� $	��44* ��� $	��46* ��� $	��46* ��� $	��46* ��� $	��47* ��� $	��44* ��� $
��135* ��� $	��92* �.+��� ���	#FF388E3C$��2���� $��0�� �� Orientation$ 
Horizontal=�$��2��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PencilPlus=�$��32��
�������$��32��$��Center=��� -    ��Name$ 
NameDialog��$+��%/Medkit;component/Fonts/#Roboto Black)�$��16(�$
��Left=�$��Center=�
�������$
��Bold"�.��Новый клиент�� -   	 ��Name$	 	FamClient��
 �� 	MaxLength$	
 100��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Фамилия клиента��   FloatingScale$
 0.90Q� %  !MaterialDesignFloatingHintTextBox#��[  $��1��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��2���� -   $	 
NameClient��$	
 100��$ Имя клиента��$
 0.90Q�#��[  $��2��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��2���� -   $	 SnameClient��$	
 100��$% Отчество клиента��$
 0.90Q�#��[  $��3��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��2��$	��Top=�$��44��%  Xceed.Wpf.Toolkit.MaskedTextBox  -     Name$ PhoneBox��$ Телефон��   Mask$ +79999999999��$
 13��$
 0.90Q�#��[  $��4��$
��15,0q�$��0��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��Bottom=�$��44��(  "System.Windows.Controls.DatePicker  -     Name$ DateDay��$ Дата рождения�� � Language$ ru-RU�$��1�� ( $MaterialDesignFloatingHintDatePicker#��[ $
 0.90Q�$��0,0,15,0q�$��4��$��Bottom=�$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��38���� -   $	 
SerialPass��$
 4��$! Серия паспорта��$
 0.90Q�#��[  $��5��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��0���� -	   $	 NumPass��$
 6��$! Номер паспорта��$
 0.90Q�#��[  $��5��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��0,0,15,0q�$��1���� $��7��$��2��$��Bottom=�$��84��.+��� -
    ��Name$ AcceptButton�� " MaterialDesignRaisedDarkButton#��[ $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�
�������.��Добавить��  �� IsCancel . #��[ $��
10,0,10,10q�$��16(�$%��/Medkit;component/Fonts/#Roboto)�
�������.��Отмена�� -   $ 
WarningMsg��$y�Hidden=����	#FFD42626$��6��$��2��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��5,0,0,0q�$��Bottom=�$��27��.��%#Заполните все поля!