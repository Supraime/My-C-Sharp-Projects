   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  "    Medkit.DialogsWindow.UserAdd   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Medkit.DialogsWindow     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  UserAdd��$	��500��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=�.���  � ColumnDefinitions �� ��  � RowDefinitions �� $	��44* ��� $	��49* ��� $	��49* ��� $	��49* ��� $	��49* ��� $	��54* ��� $	��44* ��� $	��75* ��� $	��87* �.+��� ���	#FF388E3C$��2���� $��0�� �� Orientation$ 
Horizontal=�$��2��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PencilPlus=�$��32��
�������$��32��$��Center=��� -    ��Name$ TitleDialog��$+��%/Medkit;component/Fonts/#Roboto Black)�$��16(�$
��Left=�$��Center=�
�������$
��Bold"�.��%#Новый пользователь�� -   	 ��Name$	 	LoginUser��
 �� 	MaxLength$	
 100��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��   FloatingScale$
 0.90Q� %  !MaterialDesignFloatingHintTextBox#��[  $��1��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��2���� -   $	 UsernameBox��$	
 100��$( "Имя учетной записи��$
 0.90Q�#��[  $��2��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��2���� -    ��Name$ 	StatusBox��$��3��$��2��$ Статус�� & "MaterialDesignFloatingHintComboBox#��[ $
 0.90Q�$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,4q�$��41��.@��� 
 � Tag$
 user��.��Пользователь�� $ admin��.��Администратор�� $ 
Horizontal=�$��4��$��2��.+��� -   $	 Password��$	
 100�� � ToolTip$� �Пароль должен состоять из не менее 8 символов и содержать в себе латинские буквы и цифры��$ Пароль��$
 0.90Q�#��[  $��2��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$	��350���� -   $- 'Сгенерировать пароль��
����������	#FF388E3C���	#FF388E3C$��Center=�$��Bottom=�$��0,0,0,5q���0  *MaterialDesignThemes.Wpf.PackIconExtension  *Brain+�� -   $	 RepeatPassword��$	
 100��$% Повторите пароль��$
 0.90Q�#��[  $��5��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��15,0,0,0q�$��2��$	��350��$
��Left=�$��Bottom=�$��44���� $��8��$��2��$��Bottom=�$��84��.+��� -    ��Name$ AcceptButton�� " MaterialDesignRaisedDarkButton#��[ $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�
�������.��Добавить��  �� IsCancel . #��[ $��
10,0,10,10q�$��16(�$%��/Medkit;component/Fonts/#Roboto)�
�������.��Отмена�� -	   $ 
WarningMsg��$y�Hidden=�$��2�����	#FFD42626$��7��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��5,0,0,0q�$��Bottom=�$��27��.��%#Заполните все поля!