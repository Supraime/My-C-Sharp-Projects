   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MedkitMedkit      Medkit.AcceptTalon   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   localclr-namespace:Medkit  -     �Name$  Window�� � Title$ AcceptTalon��$	��500��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=�.���  � ColumnDefinitions �� $
��189* ��� $
��311* � � RowDefinitions �� $	��55* ��� $	��45* ��� $	��45* ��� $	��45* ��� $	��45* ��� $	��45* ��� $	��45* ��� $	��45* ��� $	��45* ��� $	��45* ��� $
��165* �.+��� ���	#FF388E3C$��0q�$��2���� $��0�� �� Orientation$ 
Horizontal=�$��2��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ TextBoxPlus=�$��32��
�������$��32��$��Center=��� $+��%/Medkit;component/Fonts/#Roboto Black)�$��16(�$
��Left=�$��Center=�
�������.��Новый талон�� $��1��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,6,0,6q�$
��Bold"�$��26��$	��123��.��ФИО пациента:�� $��2��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,6,0,6q�$
��Bold"�$��26��$��40��.��	Тип:�� $��3��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,5,0,5q�$
��Bold"�$��28��$	��113��.��Направление:�� $��4��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,5,0,5q�$
��Bold"�$��28��$��49��.��	Врач:�� $��5��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,5,0,5q�$
��Bold"�$��28��$	��110��.��Дата приема:�� $��6��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,5,0,5q�$
��Bold"�$��28��$	��122��.��Время приема:�� $��7��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,5,0,5q�$
��Bold"�$��28��$	��122��.��Кабинет:�� $��8��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,5,0,5q�$
��Bold"�$��28��$��69��.��Скидка:�� $��9��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$��10,5,0,5q�$
��Bold"�$��28��$��51��.��	Цена:�� -   	 ��Name$	 FioPac��$��1��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,6q�$��26��.��
Петя�� -   $
	 Type��$��2��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,6q�$��26��.��	Тип:�� -   $
	 Napr��$��3��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,5q�$��28��.��Направление:�� -   $	 Doctor��$��4��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,5q�$��28��.��	Врач:�� -   $	 Dateofpriem��$��5��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,5q�$��28��.��Дата приема:�� -   $	 Timeofpriem��$��6��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,5q�$��28��.��Время приема:�� -   $	 CabPriem��$��7��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,5q�$��28��.��444�� -	   $
	 Sale��$��8��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,5q�$��28��.��Отсутствует�� -
   $	 Price��$��9��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Left=�$��Center=�$	��0,5q�$��28��.��	Цена:�� $��10��$��2��$��Bottom=�.+��� -    "  MaterialDesignRaisedDarkButton#��[  $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��Печать талона�� -   #��[  $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��Подтвердить�� 
 �� IsCancel
 . #��[  $��
10,0,10,10q�$��16(�$%��/Medkit;component/Fonts/#Roboto)�.��Отмена