   M S B A M L   `   `   `  ����I  EAmirhanov_Exam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Amirhanov_Exam.PagesAmirhanov_Exam.Pages  5      -    'Amirhanov_Exam.Pages.CleaningMasterPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Amirhanov_Exam.Pages     5        N� Title$  CleaningMasterPage��5	      .��5
      �� $��10q�6   .��5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      ]� ��.  $��0��6.   .+�5      �� $��../Images/logo.png��6   $��50��64   $
��Left=�6@   �� 5      $��Это конец��6   $��24(�5   
    �� Padding$ 10,0,0,0q�5   
   $��Center=�5   
   $
��Left=�5   
   �� 5      $��Right=�6    �� Orientation$ 
Horizontal=�64   .+�5      �� -   5        $��
Выйти��5      $��10q�6-   $	��100��6N   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ OrdersDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��1��6t      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Order ID��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *	OrderID+  5       $	 Адресс��6)   
 69   �� *	Address+  5!      $'	 !Количество комнат��6)   
 6D   �� *	RoomCount+  5"      $	 Площадь��6)   
 6:   �� *	TotalArea+  5#      $	 Дата��6)   
 67   �� *Date+  5$      $	 Статус��6)   
 69   �� *Statuses.StatusName+4  .System.Windows.Controls.DataGridTemplateColumn  5%      $#	 Выберите статус��6-      CellTemplate 5&      �� 5'      .R�5(   "   �� -   5        $��Выполнено��5(   )   ��6X   �� *	OrderID+5)      5+        5,      $	 Отчеты��6-    5-      �� 5.      .R�5/   "   �� -   5        $��Отчитаться��5/   )   ��6V   �� *	OrderID+50      52      54      55      56      57      