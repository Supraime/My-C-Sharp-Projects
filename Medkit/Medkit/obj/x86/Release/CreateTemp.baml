   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MedkitMedkit      Medkit.CreateTemp   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   localclr-namespace:Medkit  -     �Name$  Window�� � Title$ 
CreateTemp�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=� � Icon$ Assets/Img/medkiticon.png��$
��1260��$	��600�����	#FFEEF9FB.��� .+��� -    ��Name$ toolBar��$	��200��$
��Left=�$	��Top=�
�������$	��600������ *ActualHeight+ �� ElementName$ Window���� $	��800��$��65�����	#FF388E3C$	��Top=�� $	��800��$��65��$	��Top=�.+��� -   	 ��Name$	 	labelName��$
��sdaw��
�������$��Right=�$,��&/Medkit;component/Fonts/#Roboto Medium)�$��20(�$��	0,5,130,0q�$	��Top=��� -   $	 labelStatus��
�������$��Right=�$+��%/Medkit;component/Fonts/#Roboto Light)�$��18(�$��Bottom=�$��	0,0,130,5q�.��Сотрудник�� 
 �� Orientation$
 
Horizontal=�$��Right=�$��0,0,10,0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$# BadgeAccountHorizontalOutline=�$��50��$��50��
�������$��Right=�$��0,5,12,0q�$	��Top=��� -    &  "MaterialDesignIconForegroundButton#��[   � ToolTip$1 +Выход из учетной записи��$��Right=�.��  $��40��$��40��
�������$ 	ExitToApp=��� $
 
Horizontal=�.+��� $
 
Horizontal=�$
��Left=����� *ActualWidth+$ toolBar��.+��� $+��%/Medkit;component/Fonts/#Roboto Black)�$��36(�
�������$��Center=�$
��Left=�$��20,0,0,0q�.��Medkit�� $��3��
�������$��Right=�$��54,0,0,0q��� $	��200��$��Center=�$��Center=�.+��� -   $	 clock��$+��%/Medkit;component/Fonts/#Roboto Light)�$��15(�
�������$��Center=�.��Время: 12:00�� -   $	 	dateLabel��$+��%/Medkit;component/Fonts/#Roboto Light)�$��15(�
�������$��Bottom=�.��Дата: 13.05.2020�� $
 
Horizontal=�.+�� $��1��$
��Left=����� *ActualWidth+$ toolBar������ *ActualHeight+$ toolBar��.+��� $��0,85,0,0q�.+��� -   $��50�����	#FF388E3C  MaterialDesignFlatButton#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $
 
Horizontal=�$
��Left=�.+�  -	     Name$ iconHome��$��30��$��30��$ HomeAccount=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�.��Рабочий стол�� $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $
 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ FileEdit=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�.��Запись на прием�� $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $
 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ HumanMaleFemale=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�.��Пациенты�� $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $
 
Horizontal=�$
��Left=�.+�  $��30��$��30��$	 Cog=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�.��Настройки�� $��50�����	#FF388E3C#��[ $%��/Medkit;component/Fonts/#Roboto)�$
��Left=����� $
 
Horizontal=�$
��Left=�.+�  $��30��$��30��$ Information=�$
��Left=�$	��Top=��� ���	#FF388E3C$
��Left=�$��Bottom=�.��О программе� -
    �Name$ mainGrid��$��2��$
��1030��$��Center=�$��15,0,0,0q�.+��� $��	0,100,0,0q�.+��� $��Новый талон��  MaterialDesignCardGroupBox#���  $��16q�.  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Custom=�   
Background �	#FF388E3C   
Foreground
 �����$	��450��$%��/Medkit;component/Fonts/#Roboto)����� .R��� $
 
Horizontal=�.+�  $ TextBoxPlus=�$��32��$��32��$��Center=��� $��8,0,0,0q�$��Center=� $  MaterialDesignSubtitle1TextBlock#��[ $+��%/Medkit;component/Fonts/#Roboto Black)����� .���  � RowDefinitions �� $	��41* ��� $	��46* ��� $	��46* ��� $	��38* ��� $	��46* ��� $
��127* ��� $	��38* � � ColumnDefinitions �� $
��239* ��� $	��12* ��� $
��239* �.+��� -    ��Name$ FamBox��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Фамилия пациента��   FloatingScale$
 0.90Q� % !MaterialDesignFloatingHintTextBox#��[ $��Bottom=�$��42��$��	0,-1,23,0q�$��2���� -   $ NameBox��$ Имя пациента��$
 0.90Q�#��[ $	��Top=�$��42��$��1��$��2��$��0,0,23,0q��� -   $ OtchBox��$' !Отчество пациента��$
 0.90Q�#��[ $	��Top=�$��42��$��2��$��2��$��0,0,23,0q�(  "System.Windows.Controls.DatePicker  -     Name$ dateDay��$ Дата рождения�� ( $MaterialDesignFloatingHintDatePicker#��[ $
 0.90Q�$��0,0,0,3q�$	��120��$��3��$��Stretch=�$
��Left=��� -   $ PhoneBox��$ Телефон�� �� 	MaxLength$ 13��$
 0.90Q�#��[ $��Bottom=�$	��150��$��42��$��4��$
��Left=��� $
 
Horizontal=�$��5��$
��Left=�$	��Top=�$��42��$��0q�$	��450��.+��� $��4��$��Bottom=�$
��Left=�$%��/Medkit;component/Fonts/#Roboto)����	#FF515151$
��Bold"�.��Паспорт:�� -   $ 	SerialBox��$ 4��$ 
Серия��$
 0.90Q�#��[ $��Center=�$��50��$��42��$��2��$
��Left=��� -   $ NumPass��$ 6��$ 
Номер��$
 0.90Q�#��[ $��Center=�$��50��$��42��$��2��$
��Left=�$��5,0,0,0q��� -   
�������$��4��$��Bottom=�$- 'Найти пациента в базе��$��17,0,0,5q�$��Right=� " MaterialDesignRaisedDarkButton#��[ .��
Найти�� -   $	 	WrongData��$y�Hidden=�$��14(�$%��/Medkit;component/Fonts/#Roboto)�$��Bottom=����	#00ECECEC���	#DDFF0000.��31Введите корректные данные!�� -   $	 	SaleLabel��$y�Hidden=�$��5��$%��/Medkit;component/Fonts/#Roboto)�$��Bottom=�$��22��$��14(�.��GEНа данного клиента действует скидка 3%�� -   $	 
WarningMsg��$y�Hidden=�$��5��$%��/Medkit;component/Fonts/#Roboto)�$��Bottom=�$��22��$��14(�$��Right=����	#DDFF0000.��%#Заполните все поля!�� -    ��Name$ 	TypeTalon��$ Тип��$
 0.90Q� & "MaterialDesignFloatingHintComboBox#��[ $��2��$��42��$��0,-1,0,0q�$��Bottom=�.@��� .��!Первичный осмотр�� .��!Вторичный осмотр�� -   $ specBox��$ Направление��#��[ $��2��$��1��$��42��$��Bottom=� �� DisplayMemberPath$	 Spl��$
 0.90Q� �� SelectedValuePath$	 Num���� -   $ 	doctorBox��$ Врач��#��[ $��2��$��2��$��42��$��0q�$��Bottom=�$	 Fio��$
 0.90Q�$	 Num��  -   $ datePrim��$ Дата приема��#��[ $��0,4,0,0q�$	��120��$��35��$��2��$��3��$	��Top=�$
��Left=�$��2��$
 0.90Q��� $��2��$��4��$��Bottom=�$%��/Medkit;component/Fonts/#Roboto)�$
��Bold"����	#FF515151$��22��$��0q�.��Время приема:�� $
 Vertical=�$��5��$��2��$	��Top=�$	��127��.+�� -    �Name$ Panel�� � Orientation$ 
Horizontal=�$��2q�$	��125��.+�	� -    	�Name$ Time0��   MaterialDesignTabRadioButton#��[ $��4q� d� 	IsChecked$ FalseY�$
��8:00��$y�Hidden=�	� -   $ Time1��#��[ $��4q�$ FalseY�$
��8:30��$y�Hidden=�	� -   $ Time2��#��[ $��4q�$ FalseY�$
��9:00��$y�Hidden=�	� -   $ Time3��#��[ $��4q�$ FalseY�$
��9:30��$y�Hidden=�	� -   $ Time4��#��[ $��4q�$ FalseY�$��10:00��$y�Hidden=�	� -    $ Time5��#��[ $��4q�$ FalseY�$��10:30��$y�Hidden=�	� -!   $ Time6��#��[ $��4q�$ FalseY�$��11:00��$y�Hidden=�	� -"   $ Time7��#��[ $��4q�$ FalseY�$��11:30��$y�Hidden=�	� -#   $ Time8��#��[ $��4q�$ FalseY�$��12:00��$y�Hidden=�	� -$   $ Time9��#��[ $��4q�$ FalseY�$��12:30��$y�Hidden=�	� -%   $ Time10��#��[ $��4q�$ FalseY�$��13:30��$y�Hidden=�	� -&   $ Time11��#��[ $��4q�$ FalseY�{�.  $��14:00��$y�Hidden=�	� -'   $ Time12��#��[ $��4q�$ FalseY�$��14:30��$y�Hidden=�	� -(   $ Time13��#��[ $��4q�$ FalseY�$��15:00��$y�Hidden=�	� -)   $ Time14��#��[ $��4q�$ FalseY�$��15:30��$y�Hidden=��� $��2��$��6��$
 
Horizontal=�.+��� $��6��$%��/Medkit;component/Fonts/#Roboto)�$��18(�$��Bottom=�$
��Bold"�.��	Цена:�� -*   $	 
PriceLabel��$��6��$%��/Medkit;component/Fonts/#Roboto)�$��18(�$��Bottom=��� -+     ��Name$  AddTalon��
�������$��6��$��Bottom=�$) #Сформировать талон��$��0q�#��[ $%��/Medkit;component/Fonts/#Roboto)�$��14(�.��Добавить талон'  !MaterialDesignThemes.Wpf.Snackbar  -,   !  Name$! 	SnackInfo��$��0,0,0,10q�"   MessageQueue" 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  �� --   $ Shadow��$y�Hidden=����	#BF000000���� *ActualWidth+$ Window������ *ActualHeight+$ Window��